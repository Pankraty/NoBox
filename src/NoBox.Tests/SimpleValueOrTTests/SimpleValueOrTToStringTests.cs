using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Pankraty.NoBox.Tests.SimpleValueOrTTests
{
    using SimpleValueOrString = SimpleValueOr<String>;

    public class SimpleValueOrTToStringTests
    {
        [TestCaseSource(nameof(ToStringSources))]
        public string SimpleValueOrString_ToString(SimpleValueOrString value)
        {
            return value.ToString();
        }

        private static IEnumerable<TestCaseData> ToStringSources
        {
            get
            {
                yield return new TestCaseData((SimpleValueOrString)null).Returns(null);
                yield return new TestCaseData((SimpleValueOrString)"Test").Returns("Test");
                yield return new TestCaseData((SimpleValueOrString)123).Returns("123");
            }
        }
    }
}