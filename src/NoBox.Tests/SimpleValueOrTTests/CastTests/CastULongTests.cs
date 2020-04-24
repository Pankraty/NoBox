using NUnit.Framework;
using Pankraty.NoBox;
using System;
using System.Collections.Generic;

namespace NoBox.Tests.SimpleValueOrTTests.CastTests
{
    using SimpleValueOrString = SimpleValueOr<String>;

    public class CastULongTests : SimpleValueOrStringCastTestBase
    {
        private const ulong Default = ulong.MaxValue;

        [TestCaseSource(nameof(CastULongValidSources))]
        public T CanCastULongToNumbers<T>(Func<SimpleValueOrString, T> castMethod, ulong initialValue)
        {
            SimpleValueOrString v = initialValue;

            return castMethod(v);
        }

        private static IEnumerable<TestCaseData> CastULongValidSources
        {
            get
            {
                yield return new TestCaseData(new Func<SimpleValueOrString, sbyte   >(v => v),  (ulong)1).Returns((sbyte  )1);
                yield return new TestCaseData(new Func<SimpleValueOrString, sbyte   >(v => v),   Default).Returns((sbyte  )-1);
                yield return new TestCaseData(new Func<SimpleValueOrString, byte    >(v => v),  (ulong)1).Returns((byte   )1);
                yield return new TestCaseData(new Func<SimpleValueOrString, byte    >(v => v),   Default).Returns((byte   )255);
                yield return new TestCaseData(new Func<SimpleValueOrString, short   >(v => v),  (ulong)1).Returns((short  )1);
                yield return new TestCaseData(new Func<SimpleValueOrString, short   >(v => v),   Default).Returns((short  )-1);
                yield return new TestCaseData(new Func<SimpleValueOrString, ushort  >(v => v),  (ulong)1).Returns((ushort )1);
                yield return new TestCaseData(new Func<SimpleValueOrString, ushort  >(v => v),   Default).Returns((ushort )65535);
                yield return new TestCaseData(new Func<SimpleValueOrString, int     >(v => v),  (ulong)1).Returns((int    )1);
                yield return new TestCaseData(new Func<SimpleValueOrString, int     >(v => v),   Default).Returns((int    )-1);
                yield return new TestCaseData(new Func<SimpleValueOrString, uint    >(v => v),   Default).Returns((uint   )4294967295);
                yield return new TestCaseData(new Func<SimpleValueOrString, long    >(v => v),  (ulong)1).Returns((long   )1);
                yield return new TestCaseData(new Func<SimpleValueOrString, long    >(v => v),   Default).Returns((long   )-1);
                yield return new TestCaseData(new Func<SimpleValueOrString, ulong   >(v => v),   Default).Returns((ulong  )Default);
                yield return new TestCaseData(new Func<SimpleValueOrString, float   >(v => v),   Default).Returns((float  )Default);
                yield return new TestCaseData(new Func<SimpleValueOrString, double  >(v => v),   Default).Returns((double )Default);
                yield return new TestCaseData(new Func<SimpleValueOrString, decimal >(v => v),   Default).Returns((decimal)Default);
            }
        }

        [TestCaseSource(nameof(CastNumberInvalidSources))]
        public void CannotCastULongToNonNumbers<T>(Func<SimpleValueOrString, T> castMethod)
        {
            SimpleValueOrString v = Default;

            Assert.Throws<InvalidCastException>(() => castMethod(v));
        }
    }
}