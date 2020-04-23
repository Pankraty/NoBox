using NUnit.Framework;
using Pankraty.NoBox;
using System;
using System.Collections.Generic;

namespace NoBox.Tests.SimpleValueTests.CastTests
{
    public class CastLongTests : SimpleValueCastTestBase
    {
        private const long Default = long.MaxValue;

        [TestCaseSource(nameof(CastLongValidSources))]
        public T CanCastLongToNumbers<T>(Func<SimpleValue, T> castMethod, long initialValue)
        {
            SimpleValue v = initialValue;

            return castMethod(v);
        }

        private static IEnumerable<TestCaseData> CastLongValidSources
        {
            get
            {
                yield return new TestCaseData(new Func<SimpleValue, sbyte   >(v => v),   (long)1).Returns((sbyte  )1);
                yield return new TestCaseData(new Func<SimpleValue, sbyte   >(v => v),   Default).Returns((sbyte  )-1);
                yield return new TestCaseData(new Func<SimpleValue, byte    >(v => v),   (long)1).Returns((byte   )1);
                yield return new TestCaseData(new Func<SimpleValue, byte    >(v => v),   Default).Returns((byte   )255);
                yield return new TestCaseData(new Func<SimpleValue, short   >(v => v),   (long)1).Returns((short  )1);
                yield return new TestCaseData(new Func<SimpleValue, short   >(v => v),   Default).Returns((short  )-1);
                yield return new TestCaseData(new Func<SimpleValue, ushort  >(v => v),   (long)1).Returns((ushort )1);
                yield return new TestCaseData(new Func<SimpleValue, ushort  >(v => v),   Default).Returns((ushort )65535);
                yield return new TestCaseData(new Func<SimpleValue, int     >(v => v),   (long)1).Returns((int    )1);
                yield return new TestCaseData(new Func<SimpleValue, int     >(v => v),   Default).Returns((int    )-1);
                yield return new TestCaseData(new Func<SimpleValue, uint    >(v => v),   Default).Returns((uint   )4294967295);
                yield return new TestCaseData(new Func<SimpleValue, long    >(v => v),   Default).Returns((long   )Default);
                yield return new TestCaseData(new Func<SimpleValue, ulong   >(v => v),   Default).Returns((ulong  )Default);
                yield return new TestCaseData(new Func<SimpleValue, float   >(v => v),   Default).Returns((float  )Default);
                yield return new TestCaseData(new Func<SimpleValue, double  >(v => v),   Default).Returns((double )Default);
                yield return new TestCaseData(new Func<SimpleValue, decimal >(v => v),   Default).Returns((decimal)Default);
            }
        }

        [TestCaseSource(nameof(CastNumberInvalidSources))]
        public void CannotCastLongToNonNumbers<T>(Func<SimpleValue, T> castMethod)
        {
            SimpleValue v = Default;

            Assert.Throws<InvalidCastException>(() => castMethod(v));
        }
    }
}