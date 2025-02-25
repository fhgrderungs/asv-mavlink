using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;
using Asv.Common;
using Asv.Mavlink.V2.Minimal;

namespace Asv.Mavlink.Client
{
    public interface IHeartbeatClient:IDisposable
    {
        IRxValue<HeartbeatPayload> RawHeartbeat { get; }
        IRxValue<int> PacketRateHz { get; }
        IRxValue<double> LinkQuality { get; }
        IRxValue<LinkState> Link { get; }
    }

    public static class HeartbeatClientHelper
    {
        public static IObservable<LinkState> AfterLostConnection(this IRxValue<LinkState> src, TimeSpan lostTime, CancellationToken cancel)
        {
            return new LostConnectionSubject(src, cancel, lostTime);
        }
    }

    public class LostConnectionSubject:DisposableOnceWithCancel, IObservable<LinkState>
    {
        private readonly TimeSpan _lostTime;
        private readonly Subject<LinkState> _rx = new();
        private LinkState _prevState = LinkState.Disconnected;
        private DateTime _lastTimeDisconnected = DateTime.MinValue;

        public LostConnectionSubject(IRxValue<LinkState> src, CancellationToken cancel, TimeSpan lostTime)
        {
            _lostTime = lostTime;
            src.DistinctUntilChanged().Subscribe(OnChange, cancel);
            cancel.Register(() =>
            {
                _rx.OnCompleted();
                _rx.Dispose();
            }).DisposeItWith(Disposable);

            // first time rise
            OnChange(src.Value);
        }

        private void OnChange(LinkState linkState)
        {
            if (_prevState == LinkState.Disconnected) return;
            switch (linkState)
            {
                case LinkState.Disconnected:
                    _lastTimeDisconnected = DateTime.Now;
                    break;
                case LinkState.Downgrade:
                    break;
                case LinkState.Connected:
                    if (_prevState == LinkState.Disconnected & (DateTime.Now - _lastTimeDisconnected > _lostTime))
                    {
                        _rx.OnNext(LinkState.Connected);
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(linkState), linkState, null);
            }
            _prevState = linkState;
        }

        public IDisposable Subscribe(IObserver<LinkState> observer)
        {
            return _rx.Subscribe(observer);
        }
    }
}
