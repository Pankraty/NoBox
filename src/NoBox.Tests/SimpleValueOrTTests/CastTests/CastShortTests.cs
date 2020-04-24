using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Pankraty.NoBox.Tests.SimpleValueOrTTests.CastTests
{
    using SimpleValueOrString = SimpleValueOr<String>;

    public class CastShortTests : SimpleValueOrStringCastTestBase
    {
        private const short Default = short.MaxValue;

        [TestCaseSource(nameof(CastShortValidSources))]
        public T CanCastShortToNumbers<T>(Func<SimpleValueOrString, T> castMethod, short initialValue)
        {
            SimpleValueOrString v = initialValue;

            return castMethod(v);
        }

        private static IEnumerable<TestCaseData> CastShortValidSources
        {
            get
            {
                yield return new TestCaseData(new Func<SimpleValueOrString, sbyte   >(v => v), (short)1).Returns((sbyte  )1);
                yield return new TestCaseData(new Func<SimpleValueOrString, sbyte   >(v => v),  Default).Returns((sbyte  )-1);
                yield return new TestCaseData(new Func<SimpleValueOrString, byte    >(v => v), (short)1).Returns((byte  )1);
                yield return new TestCaseData(new Func<SimpleValueOrString, byte    >(v => v),  Default).Returns((byte  )255);
                yield return new TestCaseData(new Func<SimpleValueOrString, short   >(v => v),  Default).Returns((short  )Default);
                yield return new TestCaseData(new Func<SimpleValueOrString, ushort  >(v => v),  Default).Returns((ushort )Default);
                yield return new TestCaseData(new Func<SimpleValueOrString, int     >(v => v),  Default).Returns((int    )Default);
                yield return new TestCaseData(new Func<SimpleValueOrString, uint    >(v => v),  Default).Returns((uint   )Default);
                yield return new TestCaseData(new Func<SimpleValueOrString, long    >(v => v),  Default).Returns((long   )Default);
                yield return new TestCaseData(new Func<SimpleValueOrString, ulong   >(v => v),  Default).Returns((ulong  )Default);
                yield return new TestCaseData(new Func<SimpleValueOrString, float   >(v => v),  Default).Returns((float  )Default);
                yield return new TestCaseData(new Func<SimpleValueOrString, double  >(v => v),  Default).Returns((double )Default);
                yield return new TestCaseData(new Func<SimpleValueOrString, decimal >(v => v),  Default).Returns((decimal)Default);
            }
        }

        [TestCaseSource(nameof(CastNumberInvalidSources))]
        public void CannotCastShortToNonNumbers<T>(Func<SimpleValueOrString, T> castMethod)
        {
            SimpleValueOrString v = Default;

            Assert.Throws<InvalidCastException>(() => castMethod(v));
        }
    }
}