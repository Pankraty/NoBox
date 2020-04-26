using NUnit.Framework;
using Pankraty.NoBox.Tests.Common;
using System;
using System.Collections.Generic;

namespace Pankraty.NoBox.Tests.SimpleValueOrTTests
{
    /// <summary>
    /// Test casts of <see cref="SimpleValueOr{T}"/> created from different clr types to all supported CLR types.
    /// Actual test cases are defined in <see cref="CastSamples"/> to keep them all in one place.
    /// "Id" of the test case corresponds to the line it is defined at.
    /// </summary>
    public class SimpleValueOrTCastTests
    {
        [TestCaseSource(nameof(SimpleValueOrTValidCasts))]
        public void TestValidCasts(Action castMethod)
        {
            castMethod();
        }

        [TestCaseSource(nameof(SimpleValueOrTInvalidCasts))]
        public void TestInvalidCasts(Action castMethod)
        {
            castMethod();
        }
        
        public static IEnumerable<TestCaseData> SimpleValueOrTValidCasts => CastSamples.GetValidCasts(typeof(SimpleValueOr<String>));

        public static IEnumerable<TestCaseData> SimpleValueOrTInvalidCasts => CastSamples.GetInvalidCasts(typeof(SimpleValueOr<String>));
    }
}