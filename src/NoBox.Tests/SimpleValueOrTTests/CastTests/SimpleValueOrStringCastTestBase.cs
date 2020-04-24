using NUnit.Framework;
using Pankraty.NoBox;
using System;
using System.Collections.Generic;

namespace NoBox.Tests.SimpleValueOrTTests.CastTests
{
    using SimpleValueOrString = SimpleValueOr<String>;

    public abstract class SimpleValueOrStringCastTestBase
    {
        public static IEnumerable<TestCaseData> CastNumberInvalidSources
        {
            get
            {
                yield return new TestCaseData(new Func<SimpleValueOrString, bool          >(v => v));
                yield return new TestCaseData(new Func<SimpleValueOrString, char          >(v => v));
                yield return new TestCaseData(new Func<SimpleValueOrString, DateTime      >(v => v));
                yield return new TestCaseData(new Func<SimpleValueOrString, DateTimeOffset>(v => v));
                yield return new TestCaseData(new Func<SimpleValueOrString, TimeSpan      >(v => v));
                yield return new TestCaseData(new Func<SimpleValueOrString, Guid          >(v => v));
                yield return new TestCaseData(new Func<SimpleValueOrString, string        >(v => v));
            }
        }
    }
}