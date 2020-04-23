using NUnit.Framework;
using Pankraty.NoBox;
using System;
using System.Collections.Generic;

namespace NoBox.Tests.SimpleValueTests.CastTests
{
    public class CastBoolTests
    {
        [TestCaseSource(nameof(CastBoolInvalidSources))]
        public void CannotCastBoolToAny<T>(Func<SimpleValue, T> castMethod)
        {
            SimpleValue v = true;

            Assert.Throws<InvalidCastException>(() => castMethod(v));
        }

        private static IEnumerable<TestCaseData> CastBoolInvalidSources
        {
            get
            {
                yield return new TestCaseData(new Func<SimpleValue, sbyte   >(v => v));
                yield return new TestCaseData(new Func<SimpleValue, byte    >(v => v));
                yield return new TestCaseData(new Func<SimpleValue, short   >(v => v));
                yield return new TestCaseData(new Func<SimpleValue, ushort  >(v => v));
                yield return new TestCaseData(new Func<SimpleValue, int     >(v => v));
                yield return new TestCaseData(new Func<SimpleValue, uint    >(v => v));
                yield return new TestCaseData(new Func<SimpleValue, long    >(v => v));
                yield return new TestCaseData(new Func<SimpleValue, ulong   >(v => v));
                yield return new TestCaseData(new Func<SimpleValue, float   >(v => v));
                yield return new TestCaseData(new Func<SimpleValue, double  >(v => v));
                yield return new TestCaseData(new Func<SimpleValue, char    >(v => v));
                yield return new TestCaseData(new Func<SimpleValue, DateTime>(v => v));
                yield return new TestCaseData(new Func<SimpleValue, TimeSpan>(v => v));
                yield return new TestCaseData(new Func<SimpleValue, decimal >(v => v));
            }
        }
    }
}