using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Pankraty.NoBox.Tests.SimpleValueTests.CastTests
{
    public class CastDateTimeOffsetTests
    {
        [TestCaseSource(nameof(CastDateTimeOffsetInvalidSources))]
        public void CannotCastDateTimeOffsetToAny<T>(Func<SimpleValue, T> castMethod)
        {
            SimpleValue v = new DateTimeOffset(new DateTime(2020, 02, 20, 10, 20, 30), TimeSpan.FromHours(2));

            Assert.Throws<InvalidCastException>(() => castMethod(v));
        }

        private static IEnumerable<TestCaseData> CastDateTimeOffsetInvalidSources
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
                yield return new TestCaseData(new Func<SimpleValue, DateTime      >(v => v));
                yield return new TestCaseData(new Func<SimpleValue, TimeSpan      >(v => v));
                yield return new TestCaseData(new Func<SimpleValue, Guid          >(v => v));
                yield return new TestCaseData(new Func<SimpleValue, decimal       >(v => v));
            }
        }
    }
}