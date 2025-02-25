// MIT License
//
// Copyright (c) 2018 Alexey Voloshkevich Cursir ltd. (https://github.com/asvol)
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

// This code was generate by tool Asv.Mavlink.Shell version 1.0.0

using System;
using System.Text;
using Asv.IO;

namespace Asv.Mavlink.V2.PythonArrayTest
{

    public static class PythonArrayTestHelper
    {
        public static void RegisterPythonArrayTestDialect(this IPacketDecoder<IPacketV2<IPayload>> src)
        {
            src.Register(()=>new ArrayTest0Packet());
            src.Register(()=>new ArrayTest1Packet());
            src.Register(()=>new ArrayTest3Packet());
            src.Register(()=>new ArrayTest4Packet());
            src.Register(()=>new ArrayTest5Packet());
            src.Register(()=>new ArrayTest6Packet());
            src.Register(()=>new ArrayTest7Packet());
            src.Register(()=>new ArrayTest8Packet());
        }
    }

#region Enums


#endregion

#region Messages

    /// <summary>
    /// Array test #0.
    ///  ARRAY_TEST_0
    /// </summary>
    public class ArrayTest0Packet: PacketV2<ArrayTest0Payload>
    {
	    public const int PacketMessageId = 17150;
        public override int MessageId => PacketMessageId;
        public override byte GetCrcEtra() => 26;

        public override ArrayTest0Payload Payload { get; } = new ArrayTest0Payload();

        public override string Name => "ARRAY_TEST_0";
    }

    /// <summary>
    ///  ARRAY_TEST_0
    /// </summary>
    public class ArrayTest0Payload : IPayload
    {
        public byte GetMaxByteSize() => 33; // Summ of byte sized of all fields (include extended)
        public byte GetMinByteSize() => 33; // of byte sized of fields (exclude extended)

        public void Deserialize(ref ReadOnlySpan<byte> buffer, int payloadSize)
        {
            var index = 0;
            var endIndex = payloadSize;
            var arraySize = 0;
            arraySize = /*ArrayLength*/4 - Math.Max(0,((/*PayloadByteSize*/33 - payloadSize - /*ExtendedFieldsLength*/0)/4 /*FieldTypeByteSize*/));
            ArU32 = new uint[arraySize];
            for(var i=0;i<arraySize;i++)
            {
                ArU32[i] = BinSerialize.ReadUInt(ref buffer);index+=4;
            }
            arraySize = 4;
            for(var i=0;i<arraySize;i++)
            {
                ArU16[i] = BinSerialize.ReadUShort(ref buffer);index+=2;
            }
            V1 = (byte)BinSerialize.ReadByte(ref buffer);index+=1;
            arraySize = 4;
            for(var i=0;i<arraySize;i++)
            {
                ArI8[i] = (sbyte)BinSerialize.ReadByte(ref buffer);index+=1;
            }
            arraySize = 4;
            for(var i=0;i<arraySize;i++)
            {
                ArU8[i] = (byte)BinSerialize.ReadByte(ref buffer);index+=1;
            }

        }

        public int Serialize(ref Span<byte> buffer)
        {
            var index = 0;
            for(var i=0;i<ArU32.Length;i++)
            {
                BinSerialize.WriteUInt(ref buffer,ArU32[i]);index+=4;
            }
            for(var i=0;i<ArU16.Length;i++)
            {
                BinSerialize.WriteUShort(ref buffer,ArU16[i]);index+=2;
            }
            BinSerialize.WriteByte(ref buffer,(byte)V1);index+=1;
            for(var i=0;i<ArI8.Length;i++)
            {
                BinSerialize.WriteByte(ref buffer,(byte)ArI8[i]);index+=1;
            }
            for(var i=0;i<ArU8.Length;i++)
            {
                BinSerialize.WriteByte(ref buffer,(byte)ArU8[i]);index+=1;
            }
            return index; // /*PayloadByteSize*/33;
        }



        public void Deserialize(byte[] buffer, int offset, int payloadSize)
        {
            var index = offset;
            var endIndex = offset + payloadSize;
            var arraySize = 0;
            arraySize = /*ArrayLength*/4 - Math.Max(0,((/*PayloadByteSize*/33 - payloadSize - /*ExtendedFieldsLength*/0)/4 /*FieldTypeByteSize*/));
            ArU32 = new uint[arraySize];
            for(var i=0;i<arraySize;i++)
            {
                ArU32[i] = BitConverter.ToUInt32(buffer,index);index+=4;
            }
            arraySize = 4;
            for(var i=0;i<arraySize;i++)
            {
                ArU16[i] = BitConverter.ToUInt16(buffer,index);index+=2;
            }
            V1 = (byte)buffer[index++];
            arraySize = 4;
            for(var i=0;i<arraySize;i++)
            {
                ArI8[i] = (sbyte)buffer[index++];
            }
            arraySize = 4;
            for(var i=0;i<arraySize;i++)
            {
                ArU8[i] = (byte)buffer[index++];
            }
        }

        public int Serialize(byte[] buffer, int index)
        {
		var start = index;
            for(var i=0;i<ArU32.Length;i++)
            {
                BitConverter.GetBytes(ArU32[i]).CopyTo(buffer, index);index+=4;
            }
            for(var i=0;i<ArU16.Length;i++)
            {
                BitConverter.GetBytes(ArU16[i]).CopyTo(buffer, index);index+=2;
            }
            BitConverter.GetBytes(V1).CopyTo(buffer, index);index+=1;
            for(var i=0;i<ArI8.Length;i++)
            {
                buffer[index] = (byte)ArI8[i];index+=1;
            }
            for(var i=0;i<ArU8.Length;i++)
            {
                buffer[index] = (byte)ArU8[i];index+=1;
            }
            return index - start; // /*PayloadByteSize*/33;
        }

        /// <summary>
        /// Value array
        /// OriginName: ar_u32, Units: , IsExtended: false
        /// </summary>
        public uint[] ArU32 { get; set; } = new uint[4];
        public byte GetArU32MaxItemsCount() => 4;
        /// <summary>
        /// Value array
        /// OriginName: ar_u16, Units: , IsExtended: false
        /// </summary>
        public ushort[] ArU16 { get; } = new ushort[4];
        /// <summary>
        /// Stub field
        /// OriginName: v1, Units: , IsExtended: false
        /// </summary>
        public byte V1 { get; set; }
        /// <summary>
        /// Value array
        /// OriginName: ar_i8, Units: , IsExtended: false
        /// </summary>
        public sbyte[] ArI8 { get; } = new sbyte[4];
        /// <summary>
        /// Value array
        /// OriginName: ar_u8, Units: , IsExtended: false
        /// </summary>
        public byte[] ArU8 { get; } = new byte[4];
    }
    /// <summary>
    /// Array test #1.
    ///  ARRAY_TEST_1
    /// </summary>
    public class ArrayTest1Packet: PacketV2<ArrayTest1Payload>
    {
	    public const int PacketMessageId = 17151;
        public override int MessageId => PacketMessageId;
        public override byte GetCrcEtra() => 72;

        public override ArrayTest1Payload Payload { get; } = new ArrayTest1Payload();

        public override string Name => "ARRAY_TEST_1";
    }

    /// <summary>
    ///  ARRAY_TEST_1
    /// </summary>
    public class ArrayTest1Payload : IPayload
    {
        public byte GetMaxByteSize() => 16; // Summ of byte sized of all fields (include extended)
        public byte GetMinByteSize() => 16; // of byte sized of fields (exclude extended)

        public void Deserialize(ref ReadOnlySpan<byte> buffer, int payloadSize)
        {
            var index = 0;
            var endIndex = payloadSize;
            var arraySize = 0;
            arraySize = /*ArrayLength*/4 - Math.Max(0,((/*PayloadByteSize*/16 - payloadSize - /*ExtendedFieldsLength*/0)/4 /*FieldTypeByteSize*/));
            ArU32 = new uint[arraySize];
            for(var i=0;i<arraySize;i++)
            {
                ArU32[i] = BinSerialize.ReadUInt(ref buffer);index+=4;
            }

        }

        public int Serialize(ref Span<byte> buffer)
        {
            var index = 0;
            for(var i=0;i<ArU32.Length;i++)
            {
                BinSerialize.WriteUInt(ref buffer,ArU32[i]);index+=4;
            }
            return index; // /*PayloadByteSize*/16;
        }



        public void Deserialize(byte[] buffer, int offset, int payloadSize)
        {
            var index = offset;
            var endIndex = offset + payloadSize;
            var arraySize = 0;
            arraySize = /*ArrayLength*/4 - Math.Max(0,((/*PayloadByteSize*/16 - payloadSize - /*ExtendedFieldsLength*/0)/4 /*FieldTypeByteSize*/));
            ArU32 = new uint[arraySize];
            for(var i=0;i<arraySize;i++)
            {
                ArU32[i] = BitConverter.ToUInt32(buffer,index);index+=4;
            }
        }

        public int Serialize(byte[] buffer, int index)
        {
		var start = index;
            for(var i=0;i<ArU32.Length;i++)
            {
                BitConverter.GetBytes(ArU32[i]).CopyTo(buffer, index);index+=4;
            }
            return index - start; // /*PayloadByteSize*/16;
        }

        /// <summary>
        /// Value array
        /// OriginName: ar_u32, Units: , IsExtended: false
        /// </summary>
        public uint[] ArU32 { get; set; } = new uint[4];
        public byte GetArU32MaxItemsCount() => 4;
    }
    /// <summary>
    /// Array test #3.
    ///  ARRAY_TEST_3
    /// </summary>
    public class ArrayTest3Packet: PacketV2<ArrayTest3Payload>
    {
	    public const int PacketMessageId = 17153;
        public override int MessageId => PacketMessageId;
        public override byte GetCrcEtra() => 19;

        public override ArrayTest3Payload Payload { get; } = new ArrayTest3Payload();

        public override string Name => "ARRAY_TEST_3";
    }

    /// <summary>
    ///  ARRAY_TEST_3
    /// </summary>
    public class ArrayTest3Payload : IPayload
    {
        public byte GetMaxByteSize() => 17; // Summ of byte sized of all fields (include extended)
        public byte GetMinByteSize() => 17; // of byte sized of fields (exclude extended)

        public void Deserialize(ref ReadOnlySpan<byte> buffer, int payloadSize)
        {
            var index = 0;
            var endIndex = payloadSize;
            var arraySize = 0;
            arraySize = /*ArrayLength*/4 - Math.Max(0,((/*PayloadByteSize*/17 - payloadSize - /*ExtendedFieldsLength*/0)/4 /*FieldTypeByteSize*/));
            ArU32 = new uint[arraySize];
            for(var i=0;i<arraySize;i++)
            {
                ArU32[i] = BinSerialize.ReadUInt(ref buffer);index+=4;
            }
            V = (byte)BinSerialize.ReadByte(ref buffer);index+=1;

        }

        public int Serialize(ref Span<byte> buffer)
        {
            var index = 0;
            for(var i=0;i<ArU32.Length;i++)
            {
                BinSerialize.WriteUInt(ref buffer,ArU32[i]);index+=4;
            }
            BinSerialize.WriteByte(ref buffer,(byte)V);index+=1;
            return index; // /*PayloadByteSize*/17;
        }



        public void Deserialize(byte[] buffer, int offset, int payloadSize)
        {
            var index = offset;
            var endIndex = offset + payloadSize;
            var arraySize = 0;
            arraySize = /*ArrayLength*/4 - Math.Max(0,((/*PayloadByteSize*/17 - payloadSize - /*ExtendedFieldsLength*/0)/4 /*FieldTypeByteSize*/));
            ArU32 = new uint[arraySize];
            for(var i=0;i<arraySize;i++)
            {
                ArU32[i] = BitConverter.ToUInt32(buffer,index);index+=4;
            }
            V = (byte)buffer[index++];
        }

        public int Serialize(byte[] buffer, int index)
        {
		var start = index;
            for(var i=0;i<ArU32.Length;i++)
            {
                BitConverter.GetBytes(ArU32[i]).CopyTo(buffer, index);index+=4;
            }
            BitConverter.GetBytes(V).CopyTo(buffer, index);index+=1;
            return index - start; // /*PayloadByteSize*/17;
        }

        /// <summary>
        /// Value array
        /// OriginName: ar_u32, Units: , IsExtended: false
        /// </summary>
        public uint[] ArU32 { get; set; } = new uint[4];
        public byte GetArU32MaxItemsCount() => 4;
        /// <summary>
        /// Stub field
        /// OriginName: v, Units: , IsExtended: false
        /// </summary>
        public byte V { get; set; }
    }
    /// <summary>
    /// Array test #4.
    ///  ARRAY_TEST_4
    /// </summary>
    public class ArrayTest4Packet: PacketV2<ArrayTest4Payload>
    {
	    public const int PacketMessageId = 17154;
        public override int MessageId => PacketMessageId;
        public override byte GetCrcEtra() => 89;

        public override ArrayTest4Payload Payload { get; } = new ArrayTest4Payload();

        public override string Name => "ARRAY_TEST_4";
    }

    /// <summary>
    ///  ARRAY_TEST_4
    /// </summary>
    public class ArrayTest4Payload : IPayload
    {
        public byte GetMaxByteSize() => 17; // Summ of byte sized of all fields (include extended)
        public byte GetMinByteSize() => 17; // of byte sized of fields (exclude extended)

        public void Deserialize(ref ReadOnlySpan<byte> buffer, int payloadSize)
        {
            var index = 0;
            var endIndex = payloadSize;
            var arraySize = 0;
            arraySize = /*ArrayLength*/4 - Math.Max(0,((/*PayloadByteSize*/17 - payloadSize - /*ExtendedFieldsLength*/0)/4 /*FieldTypeByteSize*/));
            ArU32 = new uint[arraySize];
            for(var i=0;i<arraySize;i++)
            {
                ArU32[i] = BinSerialize.ReadUInt(ref buffer);index+=4;
            }
            V = (byte)BinSerialize.ReadByte(ref buffer);index+=1;

        }

        public int Serialize(ref Span<byte> buffer)
        {
            var index = 0;
            for(var i=0;i<ArU32.Length;i++)
            {
                BinSerialize.WriteUInt(ref buffer,ArU32[i]);index+=4;
            }
            BinSerialize.WriteByte(ref buffer,(byte)V);index+=1;
            return index; // /*PayloadByteSize*/17;
        }



        public void Deserialize(byte[] buffer, int offset, int payloadSize)
        {
            var index = offset;
            var endIndex = offset + payloadSize;
            var arraySize = 0;
            arraySize = /*ArrayLength*/4 - Math.Max(0,((/*PayloadByteSize*/17 - payloadSize - /*ExtendedFieldsLength*/0)/4 /*FieldTypeByteSize*/));
            ArU32 = new uint[arraySize];
            for(var i=0;i<arraySize;i++)
            {
                ArU32[i] = BitConverter.ToUInt32(buffer,index);index+=4;
            }
            V = (byte)buffer[index++];
        }

        public int Serialize(byte[] buffer, int index)
        {
		var start = index;
            for(var i=0;i<ArU32.Length;i++)
            {
                BitConverter.GetBytes(ArU32[i]).CopyTo(buffer, index);index+=4;
            }
            BitConverter.GetBytes(V).CopyTo(buffer, index);index+=1;
            return index - start; // /*PayloadByteSize*/17;
        }

        /// <summary>
        /// Value array
        /// OriginName: ar_u32, Units: , IsExtended: false
        /// </summary>
        public uint[] ArU32 { get; set; } = new uint[4];
        public byte GetArU32MaxItemsCount() => 4;
        /// <summary>
        /// Stub field
        /// OriginName: v, Units: , IsExtended: false
        /// </summary>
        public byte V { get; set; }
    }
    /// <summary>
    /// Array test #5.
    ///  ARRAY_TEST_5
    /// </summary>
    public class ArrayTest5Packet: PacketV2<ArrayTest5Payload>
    {
	    public const int PacketMessageId = 17155;
        public override int MessageId => PacketMessageId;
        public override byte GetCrcEtra() => 27;

        public override ArrayTest5Payload Payload { get; } = new ArrayTest5Payload();

        public override string Name => "ARRAY_TEST_5";
    }

    /// <summary>
    ///  ARRAY_TEST_5
    /// </summary>
    public class ArrayTest5Payload : IPayload
    {
        public byte GetMaxByteSize() => 10; // Summ of byte sized of all fields (include extended)
        public byte GetMinByteSize() => 10; // of byte sized of fields (exclude extended)

        public void Deserialize(ref ReadOnlySpan<byte> buffer, int payloadSize)
        {
            var index = 0;
            var endIndex = payloadSize;
            var arraySize = 0;
            arraySize = /*ArrayLength*/5 - Math.Max(0,((/*PayloadByteSize*/10 - payloadSize - /*ExtendedFieldsLength*/0)/1 /*FieldTypeByteSize*/));
            C1 = new char[arraySize];
            unsafe
            {
                fixed (byte* bytePointer = buffer)
                fixed (char* charPointer = C1)
                {
                    Encoding.ASCII.GetChars(bytePointer, arraySize, charPointer, C1.Length);
                }
            }
            buffer = buffer.Slice(arraySize);
            index+=arraySize;
            arraySize = 5;
            unsafe
            {
                fixed (byte* bytePointer = buffer)
                fixed (char* charPointer = C2)
                {
                    Encoding.ASCII.GetChars(bytePointer, arraySize, charPointer, C2.Length);
                }
            }
            buffer = buffer.Slice(arraySize);
            index+=arraySize;

        }

        public int Serialize(ref Span<byte> buffer)
        {
            var index = 0;
            unsafe
            {
                fixed (byte* bytePointer = buffer)
                fixed (char* charPointer = C1)
                {
                    Encoding.ASCII.GetBytes(charPointer, C1.Length, bytePointer, C1.Length);
                }
            }
            buffer = buffer.Slice(C1.Length);
            index+=C1.Length;
            unsafe
            {
                fixed (byte* bytePointer = buffer)
                fixed (char* charPointer = C2)
                {
                    Encoding.ASCII.GetBytes(charPointer, C2.Length, bytePointer, C2.Length);
                }
            }
            buffer = buffer.Slice(C2.Length);
            index+=C2.Length;
            return index; // /*PayloadByteSize*/10;
        }



        public void Deserialize(byte[] buffer, int offset, int payloadSize)
        {
            var index = offset;
            var endIndex = offset + payloadSize;
            var arraySize = 0;
            arraySize = /*ArrayLength*/5 - Math.Max(0,((/*PayloadByteSize*/10 - payloadSize - /*ExtendedFieldsLength*/0)/1 /*FieldTypeByteSize*/));
            C1 = new char[arraySize];
            Encoding.ASCII.GetChars(buffer, index,arraySize,C1,0);
            index+=arraySize;
            arraySize = 5;
            Encoding.ASCII.GetChars(buffer, index,arraySize,C2,0);
            index+=arraySize;
        }

        public int Serialize(byte[] buffer, int index)
        {
		var start = index;
            index+=Encoding.ASCII.GetBytes(C1,0,C1.Length,buffer,index);
            index+=Encoding.ASCII.GetBytes(C2,0,C2.Length,buffer,index);
            return index - start; // /*PayloadByteSize*/10;
        }

        /// <summary>
        /// Value array
        /// OriginName: c1, Units: , IsExtended: false
        /// </summary>
        public char[] C1 { get; set; } = new char[5];
        public byte GetC1MaxItemsCount() => 5;
        /// <summary>
        /// Value array
        /// OriginName: c2, Units: , IsExtended: false
        /// </summary>
        public char[] C2 { get; } = new char[5];
    }
    /// <summary>
    /// Array test #6.
    ///  ARRAY_TEST_6
    /// </summary>
    public class ArrayTest6Packet: PacketV2<ArrayTest6Payload>
    {
	    public const int PacketMessageId = 17156;
        public override int MessageId => PacketMessageId;
        public override byte GetCrcEtra() => 14;

        public override ArrayTest6Payload Payload { get; } = new ArrayTest6Payload();

        public override string Name => "ARRAY_TEST_6";
    }

    /// <summary>
    ///  ARRAY_TEST_6
    /// </summary>
    public class ArrayTest6Payload : IPayload
    {
        public byte GetMaxByteSize() => 91; // Summ of byte sized of all fields (include extended)
        public byte GetMinByteSize() => 91; // of byte sized of fields (exclude extended)

        public void Deserialize(ref ReadOnlySpan<byte> buffer, int payloadSize)
        {
            var index = 0;
            var endIndex = payloadSize;
            var arraySize = 0;
            arraySize = 2;
            for(var i=0;i<arraySize;i++)
            {
                ArD[i] = BinSerialize.ReadDouble(ref buffer);index+=8;
            }
            V3 = BinSerialize.ReadUInt(ref buffer);index+=4;
            arraySize = 2;
            for(var i=0;i<arraySize;i++)
            {
                ArU32[i] = BinSerialize.ReadUInt(ref buffer);index+=4;
            }
            arraySize = 2;
            for(var i=0;i<arraySize;i++)
            {
                ArI32[i] = BinSerialize.ReadInt(ref buffer);index+=4;
            }
            arraySize = 2;
            for(var i=0;i<arraySize;i++)
            {
                ArF[i] = BinSerialize.ReadFloat(ref buffer);index+=4;
            }
            V2 = BinSerialize.ReadUShort(ref buffer);index+=2;
            arraySize = 2;
            for(var i=0;i<arraySize;i++)
            {
                ArU16[i] = BinSerialize.ReadUShort(ref buffer);index+=2;
            }
            arraySize = 2;
            for(var i=0;i<arraySize;i++)
            {
                ArI16[i] = BinSerialize.ReadShort(ref buffer);index+=2;
            }
            V1 = (byte)BinSerialize.ReadByte(ref buffer);index+=1;
            arraySize = 2;
            for(var i=0;i<arraySize;i++)
            {
                ArU8[i] = (byte)BinSerialize.ReadByte(ref buffer);index+=1;
            }
            arraySize = 2;
            for(var i=0;i<arraySize;i++)
            {
                ArI8[i] = (sbyte)BinSerialize.ReadByte(ref buffer);index+=1;
            }
            arraySize = /*ArrayLength*/32 - Math.Max(0,((/*PayloadByteSize*/91 - payloadSize - /*ExtendedFieldsLength*/0)/1 /*FieldTypeByteSize*/));
            ArC = new char[arraySize];
            unsafe
            {
                fixed (byte* bytePointer = buffer)
                fixed (char* charPointer = ArC)
                {
                    Encoding.ASCII.GetChars(bytePointer, arraySize, charPointer, ArC.Length);
                }
            }
            buffer = buffer.Slice(arraySize);
            index+=arraySize;

        }

        public int Serialize(ref Span<byte> buffer)
        {
            var index = 0;
            for(var i=0;i<ArD.Length;i++)
            {
                BinSerialize.WriteDouble(ref buffer,ArD[i]);index+=8;
            }
            BinSerialize.WriteUInt(ref buffer,V3);index+=4;
            for(var i=0;i<ArU32.Length;i++)
            {
                BinSerialize.WriteUInt(ref buffer,ArU32[i]);index+=4;
            }
            for(var i=0;i<ArI32.Length;i++)
            {
                BinSerialize.WriteInt(ref buffer,ArI32[i]);index+=4;
            }
            for(var i=0;i<ArF.Length;i++)
            {
                BinSerialize.WriteFloat(ref buffer,ArF[i]);index+=4;
            }
            BinSerialize.WriteUShort(ref buffer,V2);index+=2;
            for(var i=0;i<ArU16.Length;i++)
            {
                BinSerialize.WriteUShort(ref buffer,ArU16[i]);index+=2;
            }
            for(var i=0;i<ArI16.Length;i++)
            {
                BinSerialize.WriteShort(ref buffer,ArI16[i]);index+=2;
            }
            BinSerialize.WriteByte(ref buffer,(byte)V1);index+=1;
            for(var i=0;i<ArU8.Length;i++)
            {
                BinSerialize.WriteByte(ref buffer,(byte)ArU8[i]);index+=1;
            }
            for(var i=0;i<ArI8.Length;i++)
            {
                BinSerialize.WriteByte(ref buffer,(byte)ArI8[i]);index+=1;
            }
            unsafe
            {
                fixed (byte* bytePointer = buffer)
                fixed (char* charPointer = ArC)
                {
                    Encoding.ASCII.GetBytes(charPointer, ArC.Length, bytePointer, ArC.Length);
                }
            }
            buffer = buffer.Slice(ArC.Length);
            index+=ArC.Length;
            return index; // /*PayloadByteSize*/91;
        }



        public void Deserialize(byte[] buffer, int offset, int payloadSize)
        {
            var index = offset;
            var endIndex = offset + payloadSize;
            var arraySize = 0;
            arraySize = 2;
            for(var i=0;i<arraySize;i++)
            {
                ArD[i] = BitConverter.ToDouble(buffer, index);index+=8;
            }
            V3 = BitConverter.ToUInt32(buffer,index);index+=4;
            arraySize = 2;
            for(var i=0;i<arraySize;i++)
            {
                ArU32[i] = BitConverter.ToUInt32(buffer,index);index+=4;
            }
            arraySize = 2;
            for(var i=0;i<arraySize;i++)
            {
                ArI32[i] = BitConverter.ToInt32(buffer,index);index+=4;
            }
            arraySize = 2;
            for(var i=0;i<arraySize;i++)
            {
                ArF[i] = BitConverter.ToSingle(buffer, index);index+=4;
            }
            V2 = BitConverter.ToUInt16(buffer,index);index+=2;
            arraySize = 2;
            for(var i=0;i<arraySize;i++)
            {
                ArU16[i] = BitConverter.ToUInt16(buffer,index);index+=2;
            }
            arraySize = 2;
            for(var i=0;i<arraySize;i++)
            {
                ArI16[i] = BitConverter.ToInt16(buffer,index);index+=2;
            }
            V1 = (byte)buffer[index++];
            arraySize = 2;
            for(var i=0;i<arraySize;i++)
            {
                ArU8[i] = (byte)buffer[index++];
            }
            arraySize = 2;
            for(var i=0;i<arraySize;i++)
            {
                ArI8[i] = (sbyte)buffer[index++];
            }
            arraySize = /*ArrayLength*/32 - Math.Max(0,((/*PayloadByteSize*/91 - payloadSize - /*ExtendedFieldsLength*/0)/1 /*FieldTypeByteSize*/));
            ArC = new char[arraySize];
            Encoding.ASCII.GetChars(buffer, index,arraySize,ArC,0);
            index+=arraySize;
        }

        public int Serialize(byte[] buffer, int index)
        {
		var start = index;
            for(var i=0;i<ArD.Length;i++)
            {
                BitConverter.GetBytes(ArD[i]).CopyTo(buffer, index);index+=8;
            }
            BitConverter.GetBytes(V3).CopyTo(buffer, index);index+=4;
            for(var i=0;i<ArU32.Length;i++)
            {
                BitConverter.GetBytes(ArU32[i]).CopyTo(buffer, index);index+=4;
            }
            for(var i=0;i<ArI32.Length;i++)
            {
                BitConverter.GetBytes(ArI32[i]).CopyTo(buffer, index);index+=4;
            }
            for(var i=0;i<ArF.Length;i++)
            {
                BitConverter.GetBytes(ArF[i]).CopyTo(buffer, index);index+=4;
            }
            BitConverter.GetBytes(V2).CopyTo(buffer, index);index+=2;
            for(var i=0;i<ArU16.Length;i++)
            {
                BitConverter.GetBytes(ArU16[i]).CopyTo(buffer, index);index+=2;
            }
            for(var i=0;i<ArI16.Length;i++)
            {
                BitConverter.GetBytes(ArI16[i]).CopyTo(buffer, index);index+=2;
            }
            BitConverter.GetBytes(V1).CopyTo(buffer, index);index+=1;
            for(var i=0;i<ArU8.Length;i++)
            {
                buffer[index] = (byte)ArU8[i];index+=1;
            }
            for(var i=0;i<ArI8.Length;i++)
            {
                buffer[index] = (byte)ArI8[i];index+=1;
            }
            index+=Encoding.ASCII.GetBytes(ArC,0,ArC.Length,buffer,index);
            return index - start; // /*PayloadByteSize*/91;
        }

        /// <summary>
        /// Value array
        /// OriginName: ar_d, Units: , IsExtended: false
        /// </summary>
        public double[] ArD { get; } = new double[2];
        /// <summary>
        /// Stub field
        /// OriginName: v3, Units: , IsExtended: false
        /// </summary>
        public uint V3 { get; set; }
        /// <summary>
        /// Value array
        /// OriginName: ar_u32, Units: , IsExtended: false
        /// </summary>
        public uint[] ArU32 { get; } = new uint[2];
        /// <summary>
        /// Value array
        /// OriginName: ar_i32, Units: , IsExtended: false
        /// </summary>
        public int[] ArI32 { get; } = new int[2];
        /// <summary>
        /// Value array
        /// OriginName: ar_f, Units: , IsExtended: false
        /// </summary>
        public float[] ArF { get; } = new float[2];
        /// <summary>
        /// Stub field
        /// OriginName: v2, Units: , IsExtended: false
        /// </summary>
        public ushort V2 { get; set; }
        /// <summary>
        /// Value array
        /// OriginName: ar_u16, Units: , IsExtended: false
        /// </summary>
        public ushort[] ArU16 { get; } = new ushort[2];
        /// <summary>
        /// Value array
        /// OriginName: ar_i16, Units: , IsExtended: false
        /// </summary>
        public short[] ArI16 { get; } = new short[2];
        /// <summary>
        /// Stub field
        /// OriginName: v1, Units: , IsExtended: false
        /// </summary>
        public byte V1 { get; set; }
        /// <summary>
        /// Value array
        /// OriginName: ar_u8, Units: , IsExtended: false
        /// </summary>
        public byte[] ArU8 { get; } = new byte[2];
        /// <summary>
        /// Value array
        /// OriginName: ar_i8, Units: , IsExtended: false
        /// </summary>
        public sbyte[] ArI8 { get; } = new sbyte[2];
        /// <summary>
        /// Value array
        /// OriginName: ar_c, Units: , IsExtended: false
        /// </summary>
        public char[] ArC { get; set; } = new char[32];
        public byte GetArCMaxItemsCount() => 32;
    }
    /// <summary>
    /// Array test #7.
    ///  ARRAY_TEST_7
    /// </summary>
    public class ArrayTest7Packet: PacketV2<ArrayTest7Payload>
    {
	    public const int PacketMessageId = 17157;
        public override int MessageId => PacketMessageId;
        public override byte GetCrcEtra() => 187;

        public override ArrayTest7Payload Payload { get; } = new ArrayTest7Payload();

        public override string Name => "ARRAY_TEST_7";
    }

    /// <summary>
    ///  ARRAY_TEST_7
    /// </summary>
    public class ArrayTest7Payload : IPayload
    {
        public byte GetMaxByteSize() => 84; // Summ of byte sized of all fields (include extended)
        public byte GetMinByteSize() => 84; // of byte sized of fields (exclude extended)

        public void Deserialize(ref ReadOnlySpan<byte> buffer, int payloadSize)
        {
            var index = 0;
            var endIndex = payloadSize;
            var arraySize = 0;
            arraySize = 2;
            for(var i=0;i<arraySize;i++)
            {
                ArD[i] = BinSerialize.ReadDouble(ref buffer);index+=8;
            }
            arraySize = 2;
            for(var i=0;i<arraySize;i++)
            {
                ArF[i] = BinSerialize.ReadFloat(ref buffer);index+=4;
            }
            arraySize = 2;
            for(var i=0;i<arraySize;i++)
            {
                ArU32[i] = BinSerialize.ReadUInt(ref buffer);index+=4;
            }
            arraySize = 2;
            for(var i=0;i<arraySize;i++)
            {
                ArI32[i] = BinSerialize.ReadInt(ref buffer);index+=4;
            }
            arraySize = 2;
            for(var i=0;i<arraySize;i++)
            {
                ArU16[i] = BinSerialize.ReadUShort(ref buffer);index+=2;
            }
            arraySize = 2;
            for(var i=0;i<arraySize;i++)
            {
                ArI16[i] = BinSerialize.ReadShort(ref buffer);index+=2;
            }
            arraySize = 2;
            for(var i=0;i<arraySize;i++)
            {
                ArU8[i] = (byte)BinSerialize.ReadByte(ref buffer);index+=1;
            }
            arraySize = 2;
            for(var i=0;i<arraySize;i++)
            {
                ArI8[i] = (sbyte)BinSerialize.ReadByte(ref buffer);index+=1;
            }
            arraySize = /*ArrayLength*/32 - Math.Max(0,((/*PayloadByteSize*/84 - payloadSize - /*ExtendedFieldsLength*/0)/1 /*FieldTypeByteSize*/));
            ArC = new char[arraySize];
            unsafe
            {
                fixed (byte* bytePointer = buffer)
                fixed (char* charPointer = ArC)
                {
                    Encoding.ASCII.GetChars(bytePointer, arraySize, charPointer, ArC.Length);
                }
            }
            buffer = buffer.Slice(arraySize);
            index+=arraySize;

        }

        public int Serialize(ref Span<byte> buffer)
        {
            var index = 0;
            for(var i=0;i<ArD.Length;i++)
            {
                BinSerialize.WriteDouble(ref buffer,ArD[i]);index+=8;
            }
            for(var i=0;i<ArF.Length;i++)
            {
                BinSerialize.WriteFloat(ref buffer,ArF[i]);index+=4;
            }
            for(var i=0;i<ArU32.Length;i++)
            {
                BinSerialize.WriteUInt(ref buffer,ArU32[i]);index+=4;
            }
            for(var i=0;i<ArI32.Length;i++)
            {
                BinSerialize.WriteInt(ref buffer,ArI32[i]);index+=4;
            }
            for(var i=0;i<ArU16.Length;i++)
            {
                BinSerialize.WriteUShort(ref buffer,ArU16[i]);index+=2;
            }
            for(var i=0;i<ArI16.Length;i++)
            {
                BinSerialize.WriteShort(ref buffer,ArI16[i]);index+=2;
            }
            for(var i=0;i<ArU8.Length;i++)
            {
                BinSerialize.WriteByte(ref buffer,(byte)ArU8[i]);index+=1;
            }
            for(var i=0;i<ArI8.Length;i++)
            {
                BinSerialize.WriteByte(ref buffer,(byte)ArI8[i]);index+=1;
            }
            unsafe
            {
                fixed (byte* bytePointer = buffer)
                fixed (char* charPointer = ArC)
                {
                    Encoding.ASCII.GetBytes(charPointer, ArC.Length, bytePointer, ArC.Length);
                }
            }
            buffer = buffer.Slice(ArC.Length);
            index+=ArC.Length;
            return index; // /*PayloadByteSize*/84;
        }



        public void Deserialize(byte[] buffer, int offset, int payloadSize)
        {
            var index = offset;
            var endIndex = offset + payloadSize;
            var arraySize = 0;
            arraySize = 2;
            for(var i=0;i<arraySize;i++)
            {
                ArD[i] = BitConverter.ToDouble(buffer, index);index+=8;
            }
            arraySize = 2;
            for(var i=0;i<arraySize;i++)
            {
                ArF[i] = BitConverter.ToSingle(buffer, index);index+=4;
            }
            arraySize = 2;
            for(var i=0;i<arraySize;i++)
            {
                ArU32[i] = BitConverter.ToUInt32(buffer,index);index+=4;
            }
            arraySize = 2;
            for(var i=0;i<arraySize;i++)
            {
                ArI32[i] = BitConverter.ToInt32(buffer,index);index+=4;
            }
            arraySize = 2;
            for(var i=0;i<arraySize;i++)
            {
                ArU16[i] = BitConverter.ToUInt16(buffer,index);index+=2;
            }
            arraySize = 2;
            for(var i=0;i<arraySize;i++)
            {
                ArI16[i] = BitConverter.ToInt16(buffer,index);index+=2;
            }
            arraySize = 2;
            for(var i=0;i<arraySize;i++)
            {
                ArU8[i] = (byte)buffer[index++];
            }
            arraySize = 2;
            for(var i=0;i<arraySize;i++)
            {
                ArI8[i] = (sbyte)buffer[index++];
            }
            arraySize = /*ArrayLength*/32 - Math.Max(0,((/*PayloadByteSize*/84 - payloadSize - /*ExtendedFieldsLength*/0)/1 /*FieldTypeByteSize*/));
            ArC = new char[arraySize];
            Encoding.ASCII.GetChars(buffer, index,arraySize,ArC,0);
            index+=arraySize;
        }

        public int Serialize(byte[] buffer, int index)
        {
		var start = index;
            for(var i=0;i<ArD.Length;i++)
            {
                BitConverter.GetBytes(ArD[i]).CopyTo(buffer, index);index+=8;
            }
            for(var i=0;i<ArF.Length;i++)
            {
                BitConverter.GetBytes(ArF[i]).CopyTo(buffer, index);index+=4;
            }
            for(var i=0;i<ArU32.Length;i++)
            {
                BitConverter.GetBytes(ArU32[i]).CopyTo(buffer, index);index+=4;
            }
            for(var i=0;i<ArI32.Length;i++)
            {
                BitConverter.GetBytes(ArI32[i]).CopyTo(buffer, index);index+=4;
            }
            for(var i=0;i<ArU16.Length;i++)
            {
                BitConverter.GetBytes(ArU16[i]).CopyTo(buffer, index);index+=2;
            }
            for(var i=0;i<ArI16.Length;i++)
            {
                BitConverter.GetBytes(ArI16[i]).CopyTo(buffer, index);index+=2;
            }
            for(var i=0;i<ArU8.Length;i++)
            {
                buffer[index] = (byte)ArU8[i];index+=1;
            }
            for(var i=0;i<ArI8.Length;i++)
            {
                buffer[index] = (byte)ArI8[i];index+=1;
            }
            index+=Encoding.ASCII.GetBytes(ArC,0,ArC.Length,buffer,index);
            return index - start; // /*PayloadByteSize*/84;
        }

        /// <summary>
        /// Value array
        /// OriginName: ar_d, Units: , IsExtended: false
        /// </summary>
        public double[] ArD { get; } = new double[2];
        /// <summary>
        /// Value array
        /// OriginName: ar_f, Units: , IsExtended: false
        /// </summary>
        public float[] ArF { get; } = new float[2];
        /// <summary>
        /// Value array
        /// OriginName: ar_u32, Units: , IsExtended: false
        /// </summary>
        public uint[] ArU32 { get; } = new uint[2];
        /// <summary>
        /// Value array
        /// OriginName: ar_i32, Units: , IsExtended: false
        /// </summary>
        public int[] ArI32 { get; } = new int[2];
        /// <summary>
        /// Value array
        /// OriginName: ar_u16, Units: , IsExtended: false
        /// </summary>
        public ushort[] ArU16 { get; } = new ushort[2];
        /// <summary>
        /// Value array
        /// OriginName: ar_i16, Units: , IsExtended: false
        /// </summary>
        public short[] ArI16 { get; } = new short[2];
        /// <summary>
        /// Value array
        /// OriginName: ar_u8, Units: , IsExtended: false
        /// </summary>
        public byte[] ArU8 { get; } = new byte[2];
        /// <summary>
        /// Value array
        /// OriginName: ar_i8, Units: , IsExtended: false
        /// </summary>
        public sbyte[] ArI8 { get; } = new sbyte[2];
        /// <summary>
        /// Value array
        /// OriginName: ar_c, Units: , IsExtended: false
        /// </summary>
        public char[] ArC { get; set; } = new char[32];
        public byte GetArCMaxItemsCount() => 32;
    }
    /// <summary>
    /// Array test #8.
    ///  ARRAY_TEST_8
    /// </summary>
    public class ArrayTest8Packet: PacketV2<ArrayTest8Payload>
    {
	    public const int PacketMessageId = 17158;
        public override int MessageId => PacketMessageId;
        public override byte GetCrcEtra() => 106;

        public override ArrayTest8Payload Payload { get; } = new ArrayTest8Payload();

        public override string Name => "ARRAY_TEST_8";
    }

    /// <summary>
    ///  ARRAY_TEST_8
    /// </summary>
    public class ArrayTest8Payload : IPayload
    {
        public byte GetMaxByteSize() => 24; // Summ of byte sized of all fields (include extended)
        public byte GetMinByteSize() => 24; // of byte sized of fields (exclude extended)

        public void Deserialize(ref ReadOnlySpan<byte> buffer, int payloadSize)
        {
            var index = 0;
            var endIndex = payloadSize;
            var arraySize = 0;
            arraySize = /*ArrayLength*/2 - Math.Max(0,((/*PayloadByteSize*/24 - payloadSize - /*ExtendedFieldsLength*/0)/8 /*FieldTypeByteSize*/));
            ArD = new double[arraySize];
            for(var i=0;i<arraySize;i++)
            {
                ArD[i] = BinSerialize.ReadDouble(ref buffer);index+=8;
            }
            V3 = BinSerialize.ReadUInt(ref buffer);index+=4;
            arraySize = 2;
            for(var i=0;i<arraySize;i++)
            {
                ArU16[i] = BinSerialize.ReadUShort(ref buffer);index+=2;
            }

        }

        public int Serialize(ref Span<byte> buffer)
        {
            var index = 0;
            for(var i=0;i<ArD.Length;i++)
            {
                BinSerialize.WriteDouble(ref buffer,ArD[i]);index+=8;
            }
            BinSerialize.WriteUInt(ref buffer,V3);index+=4;
            for(var i=0;i<ArU16.Length;i++)
            {
                BinSerialize.WriteUShort(ref buffer,ArU16[i]);index+=2;
            }
            return index; // /*PayloadByteSize*/24;
        }



        public void Deserialize(byte[] buffer, int offset, int payloadSize)
        {
            var index = offset;
            var endIndex = offset + payloadSize;
            var arraySize = 0;
            arraySize = /*ArrayLength*/2 - Math.Max(0,((/*PayloadByteSize*/24 - payloadSize - /*ExtendedFieldsLength*/0)/8 /*FieldTypeByteSize*/));
            ArD = new double[arraySize];
            for(var i=0;i<arraySize;i++)
            {
                ArD[i] = BitConverter.ToDouble(buffer, index);index+=8;
            }
            V3 = BitConverter.ToUInt32(buffer,index);index+=4;
            arraySize = 2;
            for(var i=0;i<arraySize;i++)
            {
                ArU16[i] = BitConverter.ToUInt16(buffer,index);index+=2;
            }
        }

        public int Serialize(byte[] buffer, int index)
        {
		var start = index;
            for(var i=0;i<ArD.Length;i++)
            {
                BitConverter.GetBytes(ArD[i]).CopyTo(buffer, index);index+=8;
            }
            BitConverter.GetBytes(V3).CopyTo(buffer, index);index+=4;
            for(var i=0;i<ArU16.Length;i++)
            {
                BitConverter.GetBytes(ArU16[i]).CopyTo(buffer, index);index+=2;
            }
            return index - start; // /*PayloadByteSize*/24;
        }

        /// <summary>
        /// Value array
        /// OriginName: ar_d, Units: , IsExtended: false
        /// </summary>
        public double[] ArD { get; set; } = new double[2];
        public byte GetArDMaxItemsCount() => 2;
        /// <summary>
        /// Stub field
        /// OriginName: v3, Units: , IsExtended: false
        /// </summary>
        public uint V3 { get; set; }
        /// <summary>
        /// Value array
        /// OriginName: ar_u16, Units: , IsExtended: false
        /// </summary>
        public ushort[] ArU16 { get; } = new ushort[2];
    }


#endregion


}
