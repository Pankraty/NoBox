using System;

namespace Pankraty.NoBox.Benchmarks.Generators
{
    internal class ShortValuesGenerator
    {
        private long _counter;

        public ShortValue GetNext()
        {
            var rem = _counter % 13;
            _counter++;

            return rem switch
            {
                0 => (bool)true,
                1 => (sbyte)1,
                2 => (byte)2,
                3 => (short)3,
                4 => (ushort)4,
                5 => (int)5,
                6 => (uint)6,
                7 => (long)7,
                8 => (ulong)8,
                9 => (float)9.5,
                10 => (double)10.5,
                11 => (char)'A',
                12 => new DateTime(2020, 01, 01),
                _ => TimeSpan.FromHours(1),
            };
        }
    }
}