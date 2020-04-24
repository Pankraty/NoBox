using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Pankraty.NoBox.Tests.SimpleValueOrTTests.CastTests
{
    using SimpleValueOrString = SimpleValueOr<String>;

    public class CastDateTimeOffsetTests
    {
        [TestCaseSource(nameof(CastDateTimeOffsetInvalidSources))]
        public void CannotCastDateTimeOffsetToAny<T>(Func<SimpleValueOrString, T> castMethod)
        {
            SimpleValue v = new DateTimeOffset(new DateTime(2020, 02, 20, 10, 20, 30), TimeSpan.FromHours(2));

            Assert.Throws<InvalidCastException>(() => castMethod(v));
        }

        private static IEnumerable<TestCaseData> CastDateTimeOffsetInvalidSources
        {
            get
            {
                yield return new TestCaseData(new Func<SimpleValueOrString, bool          >(v => v));
                yield return new TestCaseData(new Func<SimpleValueOrString, sbyte         >(v => v));
                yield return new TestCaseData(new Func<SimpleValueOrString, byte          >(v => v));
                yield return new TestCaseData(new Func<SimpleValueOrString, short         >(v => v));
                yield return new TestCaseData(new Func<SimpleValueOrString, ushort        >(v => v));
                yield return new TestCaseData(new Func<SimpleValueOrString, int           >(v => v));
                yield return new TestCaseData(new Func<SimpleValueOrString, uint          >(v => v));
                yield return new TestCaseData(new Func<SimpleValueOrString, long          >(v => v));
                yield return new TestCaseData(new Func<SimpleValueOrString, ulong         >(v => v));
                yield return new TestCaseData(new Func<SimpleValueOrString, float         >(v => v));
                yield return new TestCaseData(new Func<SimpleValueOrString, double        >(v => v));
                yield return new TestCaseData(new Func<SimpleValueOrString, char          >(v => v));
                yield return new TestCaseData(new Func<SimpleValueOrString, DateTime      >(v => v));
                yield return new TestCaseData(new Func<SimpleValueOrString, TimeSpan      >(v => v));
                yield return new TestCaseData(new Func<SimpleValueOrString, Guid          >(v => v));
                yield return new TestCaseData(new Func<SimpleValueOrString, decimal       >(v => v));
                yield return new TestCaseData(new Func<SimpleValueOrString, string        >(v => v));
            }
        }
    }
}