using NUnit.Framework;
using Pankraty.NoBox;
using System;
using System.Collections.Generic;

namespace NoBox.Tests.SimpleValueOrTTests.CastTests
{
    using SimpleValueOrString = SimpleValueOr<String>;

    public class CastTimeSpanTests
    {
        [TestCaseSource(nameof(CastTimeSpanInvalidSources))]
        public void CannotCastTimeSpanToAny<T>(Func<SimpleValueOrString, T> castMethod)
        {
            SimpleValueOrString v = TimeSpan.FromHours(5);

            Assert.Throws<InvalidCastException>(() => castMethod(v));
        }

        private static IEnumerable<TestCaseData> CastTimeSpanInvalidSources
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
                yield return new TestCaseData(new Func<SimpleValueOrString, DateTimeOffset>(v => v));
                yield return new TestCaseData(new Func<SimpleValueOrString, Guid          >(v => v));
                yield return new TestCaseData(new Func<SimpleValueOrString, decimal       >(v => v));
                yield return new TestCaseData(new Func<SimpleValueOrString, string        >(v => v));
            }
        }
    }
}