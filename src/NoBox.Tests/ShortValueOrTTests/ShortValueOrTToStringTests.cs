using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Pankraty.NoBox.Tests.ShortValueOrTTests
{
    using ShortValueOrString = ShortValueOr<String>;

    public class ShortValueOrTToStringTests
    {
        [TestCaseSource(nameof(ToStringSources))]
        public string ShortValueOrString_ToString(ShortValueOrString value)
        {
            return value.ToString();
        }

        private static IEnumerable<TestCaseData> ToStringSources
        {
            get
            {
                yield return new TestCaseData((ShortValueOrString)null).Returns(null);
                yield return new TestCaseData((ShortValueOrString)"Test").Returns("Test");
                yield return new TestCaseData((ShortValueOrString)123).Returns("123");
            }
        }
    }
}