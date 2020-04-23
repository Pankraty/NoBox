using NUnit.Framework;
using Pankraty.NoBox;
using System;
using System.Collections.Generic;

namespace NoBox.Tests.SimpleValueTests.CastTests
{
    public class CastDateTimeTests
    {
        [Test]
        public void CanCastDateTimeToDateTimeOffset()
        {
            SimpleValue v =new DateTime(2020, 02, 20, 10, 20, 30);

            var actualValue = (DateTimeOffset)v;
            var expectedValue = new DateTimeOffset(new DateTime(2020, 02, 20, 10, 20, 30));
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestCaseSource(nameof(CastDateTimeInvalidSources))]
        public void CannotCastDateTimeToNonDates<T>(Func<SimpleValue, T> castMethod)
        {
            SimpleValue v = new DateTime(2020, 02, 20);

            Assert.Throws<InvalidCastException>(() => castMethod(v));
        }

        private static IEnumerable<TestCaseData> CastDateTimeInvalidSources
        {
            get
            {
                yield return new TestCaseData(new Func<SimpleValue, bool          >(v => v));
                yield return new TestCaseData(new Func<SimpleValue, sbyte         >(v => v));
                yield return new TestCaseData(new Func<SimpleValue, byte          >(v => v));
                yield return new TestCaseData(new Func<SimpleValue, short         >(v => v));
                yield return new TestCaseData(new Func<SimpleValue, ushort        >(v => v));
                yield return new TestCaseData(new Func<SimpleValue, int           >(v => v));
                yield return new TestCaseData(new Func<SimpleValue, uint          >(v => v));
                yield return new TestCaseData(new Func<SimpleValue, long          >(v => v));
                yield return new TestCaseData(new Func<SimpleValue, ulong         >(v => v));
                yield return new TestCaseData(new Func<SimpleValue, float         >(v => v));
                yield return new TestCaseData(new Func<SimpleValue, double        >(v => v));
                yield return new TestCaseData(new Func<SimpleValue, char          >(v => v));
                yield return new TestCaseData(new Func<SimpleValue, TimeSpan      >(v => v));
                yield return new TestCaseData(new Func<SimpleValue, Guid          >(v => v));
                yield return new TestCaseData(new Func<SimpleValue, decimal       >(v => v));
            }
        }
    }
}