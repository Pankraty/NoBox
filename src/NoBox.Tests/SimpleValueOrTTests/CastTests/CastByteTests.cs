using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Pankraty.NoBox.Tests.SimpleValueOrTTests.CastTests
{
    using SimpleValueOrString = SimpleValueOr<String>;

    public class CastByteTests : SimpleValueOrStringCastTestBase
    {
        private const byte Default = byte.MaxValue;

        [TestCaseSource(nameof(CastByteValidSources))]
        public T CanCastByteToNumbers<T>(Func<SimpleValueOrString, T> castMethod, byte initialValue)
        {
            SimpleValue v = initialValue;

            return castMethod(v);
        }

        private static IEnumerable<TestCaseData> CastByteValidSources
        {
            get
            {
                yield return new TestCaseData(new Func<SimpleValueOrString, sbyte   >(v => v), (byte)1).Returns((sbyte  )1);
                yield return new TestCaseData(new Func<SimpleValueOrString, sbyte   >(v => v), Default).Returns((sbyte  )-1);
                yield return new TestCaseData(new Func<SimpleValueOrString, byte    >(v => v), Default).Returns((byte   )Default);
                yield return new TestCaseData(new Func<SimpleValueOrString, short   >(v => v), Default).Returns((short  )Default);
                yield return new TestCaseData(new Func<SimpleValueOrString, ushort  >(v => v), Default).Returns((ushort )Default);
                yield return new TestCaseData(new Func<SimpleValueOrString, int     >(v => v), Default).Returns((int    )Default);
                yield return new TestCaseData(new Func<SimpleValueOrString, uint    >(v => v), Default).Returns((uint   )Default);
                yield return new TestCaseData(new Func<SimpleValueOrString, long    >(v => v), Default).Returns((long   )Default);
                yield return new TestCaseData(new Func<SimpleValueOrString, ulong   >(v => v), Default).Returns((ulong  )Default);
                yield return new TestCaseData(new Func<SimpleValueOrString, float   >(v => v), Default).Returns((float  )Default);
                yield return new TestCaseData(new Func<SimpleValueOrString, double  >(v => v), Default).Returns((double )Default);
                yield return new TestCaseData(new Func<SimpleValueOrString, decimal >(v => v), Default).Returns((decimal)Default);
            }
        }

        [TestCaseSource(nameof(CastNumberInvalidSources))]
        public void CannotCastByteToNonNumbers<T>(Func<SimpleValueOrString, T> castMethod)
        {
            SimpleValue v = Default;

            Assert.Throws<InvalidCastException>(() => castMethod(v));
        }
    }
}