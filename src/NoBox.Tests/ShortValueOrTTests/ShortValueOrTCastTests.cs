using NUnit.Framework;
using Pankraty.NoBox.Tests.Common;
using System;
using System.Collections.Generic;

namespace Pankraty.NoBox.Tests.ShortValueOrTTests
{
    /// <summary>
    /// Test casts of <see cref="ShortValueOr{T}"/> created from different clr types to all supported CLR types.
    /// Actual test cases are defined in <see cref="CastSamples"/> to keep them all in one place.
    /// "Id" of the test case corresponds to the line it is defined at.
    /// </summary>
    public class ShortValueOrTCastTests
    {
        [TestCaseSource(nameof(ShortValueOrTValidCasts))]
        public void TestValidCasts(Action castMethod)
        {
            castMethod();
        }

        [TestCaseSource(nameof(ShortValueOrTInvalidCasts))]
        public void TestInvalidCasts(Action castMethod)
        {
            castMethod();
        }
        
        public static IEnumerable<TestCaseData> ShortValueOrTValidCasts => CastSamples.GetValidCasts(typeof(ShortValueOr<String>));

        public static IEnumerable<TestCaseData> ShortValueOrTInvalidCasts => CastSamples.GetInvalidCasts(typeof(ShortValueOr<String>));
    }
}