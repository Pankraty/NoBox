using System;
using Pankraty.NoBox;

namespace NoBox.Benchmarks.Generators
{
    internal class SimpleValuesGenerator
    {
        private int _counter;

        public SimpleValue GetNext()
        {
            var rem = _counter % 14;
            _counter++;

            switch (rem)
            {
                case 0: return true;
                case 1: return (sbyte)1;
                case 2: return (byte)2;
                case 3: return (short)3;
                case 4: return (ushort)4;
                case 5: return (int)5;
                case 6: return (uint)6;
                case 7: return (long)7;
                case 8: return (ulong)8;
                case 9: return (float)9.5;
                case 10: return (double)10.5;
                case 11: return (decimal)11.5m;
                case 12: return (char)'A';
                case 13: return new DateTime(2020, 01, 01);
                default: return TimeSpan.FromHours(1);
            }
        }
    }
}