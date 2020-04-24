using NUnit.Framework;
using Pankraty.NoBox.Tests.SimpleValueTests.CastTests;
using System;
using System.Collections.Generic;

namespace Pankraty.NoBox.Tests.SimpleValueOrTTests.CastTests
{
    using SimpleValueOrString = SimpleValueOr<String>;

    public class CastCharTests : SimpleValueOrStringCastTestBase
    {
        private const char Default = 'd';
        
        [TestCaseSource(nameof(CastCharValidSources))]
        public T CanCastCharToNumbers<T>(Func<SimpleValueOrString, T> castMethod, char initialValue)
        {
            SimpleValueOrString v = initialValue;

            return castMethod(v);
        }

        private static IEnumerable<TestCaseData> CastCharValidSources
        {
            get
            {
                yield return new TestCaseData(new Func<SimpleValueOrString, sbyte   >(v => v), Default).Returns((sbyte  )Default);
                yield return new TestCaseData(new Func<SimpleValueOrString, byte    >(v => v), Default).Returns((byte   )Default);
                yield return new TestCaseData(new Func<SimpleValueOrString, short   >(v => v), Default).Returns((short  )Default);
                yield return new TestCaseData(new Func<SimpleValueOrString, ushort  >(v => v), Default).Returns((ushort )Default);
                yield return new TestCaseData(new Func<SimpleValueOrString, int     >(v => v), Default).Returns((int    )Default);
                yield return new TestCaseData(new Func<SimpleValueOrString, uint    >(v => v), Default).Returns((uint   )Default);
                yield return new TestCaseData(new Func<SimpleValueOrString, long    >(v => v), Default).Returns((long   )Default);
                yield return new TestCaseData(new Func<SimpleValueOrString, ulong   >(v => v), Default).Returns((ulong  )Default);
                yield return new TestCaseData(new Func<SimpleValueOrString, float   >(v => v), Default).Returns((float  )Default);
                yield return new TestCaseData(new Func<SimpleValueOrString, double  >(v => v), Default).Returns((double )Default);
                yield return new TestCaseData(new Func<SimpleValueOrString, char    >(v => v), Default).Returns((char   )Default);
                yield return new TestCaseData(new Func<SimpleValueOrString, decimal >(v => v), Default).Returns((decimal)Default);
            }
        }

        [TestCaseSource(nameof(CastNumberInvalidSources))]
        public void CannotCastCharToNonNumbers<T>(Func<SimpleValueOrString, T> castMethod)
        {
            SimpleValueOrString v = Default;

            Assert.Throws<InvalidCastException>(() => castMethod(v));
        }
    }
}