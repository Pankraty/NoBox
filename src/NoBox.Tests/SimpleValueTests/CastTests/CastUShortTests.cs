using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Pankraty.NoBox.Tests.SimpleValueTests.CastTests
{
    public class CastUShortTests : SimpleValueCastTestBase
    {
        private const ushort Default = ushort.MaxValue;

        [TestCaseSource(nameof(CastUShortValidSources))]
        public T CanCastUShortToNumbers<T>(Func<SimpleValue, T> castMethod, ushort initialValue)
        {
            SimpleValue v = initialValue;

            return castMethod(v);
        }

        private static IEnumerable<TestCaseData> CastUShortValidSources
        {
            get
            {
                yield return new TestCaseData(new Func<SimpleValue, sbyte   >(v => v), (ushort)1).Returns((sbyte  )1);
                yield return new TestCaseData(new Func<SimpleValue, sbyte   >(v => v),   Default).Returns((sbyte  )-1);
                yield return new TestCaseData(new Func<SimpleValue, byte    >(v => v), (ushort)1).Returns((byte  )1);
                yield return new TestCaseData(new Func<SimpleValue, byte    >(v => v),   Default).Returns((byte  )255);
                yield return new TestCaseData(new Func<SimpleValue, short   >(v => v), (ushort)1).Returns((short  )1);
                yield return new TestCaseData(new Func<SimpleValue, short   >(v => v),   Default).Returns((short  )-1);
                yield return new TestCaseData(new Func<SimpleValue, ushort  >(v => v),   Default).Returns((ushort )Default);
                yield return new TestCaseData(new Func<SimpleValue, int     >(v => v),   Default).Returns((int    )Default);
                yield return new TestCaseData(new Func<SimpleValue, uint    >(v => v),   Default).Returns((uint   )Default);
                yield return new TestCaseData(new Func<SimpleValue, long    >(v => v),   Default).Returns((long   )Default);
                yield return new TestCaseData(new Func<SimpleValue, ulong   >(v => v),   Default).Returns((ulong  )Default);
                yield return new TestCaseData(new Func<SimpleValue, float   >(v => v),   Default).Returns((float  )Default);
                yield return new TestCaseData(new Func<SimpleValue, double  >(v => v),   Default).Returns((double )Default);
                yield return new TestCaseData(new Func<SimpleValue, decimal >(v => v),   Default).Returns((decimal)Default);
            }
        }

        [TestCaseSource(nameof(CastNumberInvalidSources))]
        public void CannotCastUShortToNonNumbers<T>(Func<SimpleValue, T> castMethod)
        {
            SimpleValue v = Default;

            Assert.Throws<InvalidCastException>(() => castMethod(v));
        }
    }
}