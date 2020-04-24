using Pankraty.NoBox;
using System;

namespace NoBox.Benchmarks.Generators
{
    internal class SimpleValuesGenerator
    {
        private int _counter;

        public SimpleValue GetNext()
        {
            var rem = _counter % 16;
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
                11 => (decimal)11.5m,
                12 => (char)'A',
                13 => new DateTime(2020, 01, 01),
                14 => new DateTimeOffset(new DateTime(2020, 01, 01), TimeSpan.FromHours(1)),
                15 => TimeSpan.FromHours(1),
                _ => Guid.NewGuid()
            };
        }
    }
}