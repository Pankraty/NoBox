using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Pankraty.NoBox.Tests.SimpleValueTests.CastTests
{
    public class CastDecimalTests : SimpleValueCastTestBase
    {
        private const decimal Default = 12.345m;

        [TestCaseSource(nameof(CastDecimalValidSources))]
        public T CanCastDecimalToNumbers<T>(Func<SimpleValue, T> castMethod)
        {
            SimpleValue v = Default;

            return castMethod(v);
        }

        private static IEnumerable<TestCaseData> CastDecimalValidSources
        {
            get
            {
                yield return new TestCaseData(new Func<SimpleValue, sbyte   >(v => v)).Returns((sbyte  )Default);
                yield return new TestCaseData(new Func<SimpleValue, byte    >(v => v)).Returns((byte   )Default);
                yield return new TestCaseData(new Func<SimpleValue, short   >(v => v)).Returns((short  )Default);
                yield return new TestCaseData(new Func<SimpleValue, ushort  >(v => v)).Returns((ushort )Default);
                yield return new TestCaseData(new Func<SimpleValue, int     >(v => v)).Returns((int    )Default);
                yield return new TestCaseData(new Func<SimpleValue, uint    >(v => v)).Returns((uint   )Default);
                yield return new TestCaseData(new Func<SimpleValue, long    >(v => v)).Returns((long   )Default);
                yield return new TestCaseData(new Func<SimpleValue, ulong   >(v => v)).Returns((ulong  )Default);
                yield return new TestCaseData(new Func<SimpleValue, float   >(v => v)).Returns((float  )Default);
                yield return new TestCaseData(new Func<SimpleValue, double  >(v => v)).Returns((double )Default);
                yield return new TestCaseData(new Func<SimpleValue, char    >(v => v)).Returns((char   )Default);
                yield return new TestCaseData(new Func<SimpleValue, decimal >(v => v)).Returns((decimal)Default);
            }
        }

        [TestCaseSource(nameof(CastNumberInvalidSources))]
        public void CannotCastDoubleToNonNumbers<T>(Func<SimpleValue, T> castMethod)
        {
            SimpleValue v = Default;

            Assert.Throws<InvalidCastException>(() => castMethod(v));
        }
    }
}