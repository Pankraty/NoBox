using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Pankraty.NoBox.Tests.SimpleValueOrTTests.CastTests
{
    using SimpleValueOrString = SimpleValueOr<String>;

    public class CastDoubleTests : SimpleValueOrStringCastTestBase
    {
        private const double Default = 12.345d;

        [TestCaseSource(nameof(CastDoubleValidSources))]
        public T CanCastDoubleToNumbers<T>(Func<SimpleValueOrString, T> castMethod)
        {
            SimpleValue v = Default;

            return castMethod(v);
        }

        private static IEnumerable<TestCaseData> CastDoubleValidSources
        {
            get
            {
                yield return new TestCaseData(new Func<SimpleValueOrString, sbyte   >(v => v)).Returns((sbyte  )Default);
                yield return new TestCaseData(new Func<SimpleValueOrString, byte    >(v => v)).Returns((byte   )Default);
                yield return new TestCaseData(new Func<SimpleValueOrString, short   >(v => v)).Returns((short  )Default);
                yield return new TestCaseData(new Func<SimpleValueOrString, ushort  >(v => v)).Returns((ushort )Default);
                yield return new TestCaseData(new Func<SimpleValueOrString, int     >(v => v)).Returns((int    )Default);
                yield return new TestCaseData(new Func<SimpleValueOrString, uint    >(v => v)).Returns((uint   )Default);
                yield return new TestCaseData(new Func<SimpleValueOrString, long    >(v => v)).Returns((long   )Default);
                yield return new TestCaseData(new Func<SimpleValueOrString, ulong   >(v => v)).Returns((ulong  )Default);
                yield return new TestCaseData(new Func<SimpleValueOrString, float   >(v => v)).Returns((float  )Default);
                yield return new TestCaseData(new Func<SimpleValueOrString, double  >(v => v)).Returns((double )Default);
                yield return new TestCaseData(new Func<SimpleValueOrString, decimal >(v => v)).Returns((decimal)Default);
            }
        }

        [TestCaseSource(nameof(CastNumberInvalidSources))]
        public void CannotCastDoubleToNonNumbers<T>(Func<SimpleValueOrString, T> castMethod)
        {
            SimpleValueOrString v = Default;

            Assert.Throws<InvalidCastException>(() => castMethod(v));
        }
    }
}