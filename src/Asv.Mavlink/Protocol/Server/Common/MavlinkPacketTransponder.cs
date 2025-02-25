using System;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using Asv.Common;
using NLog;

namespace Asv.Mavlink
{
    public class MavlinkPacketTransponder<TPacket,TPayload> : DisposableOnceWithCancel, IMavlinkPacketTransponder<TPacket,TPayload>
        where TPacket : IPacketV2<TPayload>, new()
        where TPayload : IPayload, new()
    {
        private readonly IMavlinkV2Connection _connection;
        private readonly MavlinkServerIdentity _identityConfig;
        private readonly IPacketSequenceCalculator _seq;
        private readonly object _sync = new();
        private IDisposable _timerSubscribe;
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();
        private readonly AsyncReaderWriterLock _dataLock = new();
        private int _isSending;
        private readonly RxValue<PacketTransponderState> _state = new RxValue<PacketTransponderState>();
        private TPacket _packet;

        public MavlinkPacketTransponder(IMavlinkV2Connection connection, MavlinkServerIdentity identityConfig, IPacketSequenceCalculator seq)
        {
            _connection = connection ?? throw new ArgumentNullException(nameof(connection));
            _identityConfig = identityConfig ?? throw new ArgumentNullException(nameof(identityConfig));
            _seq = seq ?? throw new ArgumentNullException(nameof(seq));
        }

        public void Start(TimeSpan rate)
        {
            if (_packet == null) throw new Exception($"You need call '{nameof(Set)}' method< before call start");
            lock (_sync)
            {
                if (IsStarted)
                {
                    _timerSubscribe?.Dispose();
                    _timerSubscribe = null;
                }

                IsStarted = true;
                _timerSubscribe = Observable.Timer(TimeSpan.FromMilliseconds(1), rate).Subscribe(OnTick);
            }
        }

        private async void OnTick(long l)
        {
            if (Interlocked.CompareExchange(ref _isSending, 1, 0) == 1)
            {
                LogSkipped();
                return;
            }

            try
            {

                await _dataLock.AcquireReaderLock(DisposeCancel);
                ((IPacketV2<IPayload>) _packet).Sequence = _seq.GetNextSequenceNumber();
                await _connection.Send((IPacketV2<IPayload>) _packet, DisposeCancel).ConfigureAwait(false);
                LogSuccess();
            }
            catch (Exception e)
            {
                LogError(e);
               
            }
            finally
            {
                _dataLock.ReleaseReaderLock();
                Interlocked.Exchange(ref _isSending, 0);
            }
        }

        private void LogError(Exception e)
        {
            if (_state.Value == PacketTransponderState.ErrorToSend) return;
            _state.OnNext(PacketTransponderState.ErrorToSend);
            _logger.Error( $"{new TPacket().Name} sending error:{e.Message}");
        }

        private void LogSuccess()
        {
            if (_state.Value == PacketTransponderState.Ok) return;
            _state.OnNext(PacketTransponderState.Ok);
            _logger.Debug($"{new TPacket().Name} start stream");
        }

        private void LogSkipped()
        {
            if (_state.Value == PacketTransponderState.Skipped) return;
            _state.OnNext(PacketTransponderState.Skipped);
            _logger.Warn($"{new TPacket().Name} skipped sending: previous command has not yet been executed");
        }

        public bool IsStarted { get; private set; }

        public IRxValue<PacketTransponderState> State => _state;

        public void Stop()
        {
            lock (_sync)
            {
                _timerSubscribe?.Dispose();
                _timerSubscribe = null;
                IsStarted = false;
            }
        }

        public async Task Set(Action<TPayload> changeCallback)
        {
            try
            {
                await _dataLock.AcquireWriterLock();
                _packet = new TPacket
                {
                    CompatFlags = 0,
                    IncompatFlags = 0,
                    ComponenId = _identityConfig.ComponentId,
                    SystemId = _identityConfig.SystemId,
                };
                changeCallback(_packet.Payload);

            }
            catch (Exception e)
            {
                _logger.Error( $"Error to set new value for {new TPacket().Name}:{e.Message}");
            }
            finally
            {
                _dataLock.ReleaseWriterLock();
            }
        }

        protected override void InternalDisposeOnce()
        {
            base.InternalDisposeOnce();
            _dataLock.Dispose();
            Stop();
            _state?.Dispose();
        }
    }
}
