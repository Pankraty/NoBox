using System;
using NUnit.Framework;

namespace NoBox.Tests
{
    public abstract class TheoryTestBase
    {
        [DatapointSource] public byte[] Bytes         = new[] { byte.MinValue, (byte)1, byte.MaxValue};
        [DatapointSource] public char[] Chars         = new[] { char.MinValue, '$'};
        [DatapointSource] public DateTime[] DateTimes = new[] { DateTime.MinValue, new DateTime(2020, 02, 20), DateTime.MaxValue};
        [DatapointSource] public decimal[] Decimals   = new[] { decimal.MinValue, 0m, 0.123m, decimal.MaxValue};
        [DatapointSource] public double[] Doubles     = new[] { double.MinValue, 0, 0.123, double.MaxValue};
        [DatapointSource] public float[] Floats       = new[] { float.MinValue, (float)0, (float)0.123, float.MaxValue};
        [DatapointSource] public int[] Ints           = new[] { int.MinValue, 0, 10, int.MaxValue};
        [DatapointSource] public long[] Longs         = new[] { long.MinValue, (long)0, (long)10, long.MaxValue};
        [DatapointSource] public sbyte[] SBytes       = new[] { sbyte.MinValue, (sbyte)0, (sbyte)10, sbyte.MaxValue};
        [DatapointSource] public short[] Shorts       = new[] { short.MinValue, (short)0, (short)10, short.MaxValue};
        [DatapointSource] public TimeSpan[] TimeSpans = new[] { TimeSpan.MinValue, TimeSpan.Zero, TimeSpan.FromDays(1), TimeSpan.MaxValue };
        [DatapointSource] public uint[] UInts         = new[] { uint.MinValue, (uint)0, (uint)10, uint.MaxValue };
        [DatapointSource] public ulong[] ULongs       = new[] { ulong.MinValue, (ulong)0, (ulong)10, ulong.MaxValue };
        [DatapointSource] public ushort[] UShorts     = new[] { ushort.MinValue, (ushort)0, (ushort)10, ushort.MaxValue };
    }
}