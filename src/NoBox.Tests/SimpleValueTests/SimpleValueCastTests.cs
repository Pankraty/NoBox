using NUnit.Framework;
using Pankraty.NoBox.Tests.Common;
using System;
using System.Collections.Generic;

namespace Pankraty.NoBox.Tests.SimpleValueTests
{
    /// <summary>
    /// Test casts of <see cref="SimpleValue"/> created from different clr types to all supported CLR types.
    /// Actual test cases are defined in <see cref="CastSamples"/> to keep them all in one place.
    /// "Id" of the test case corresponds to the line it is defined at.
    /// </summary>
    public class SimpleValueCastTests
    {
        [TestCaseSource(nameof(SimpleValueValidCasts))]
        public void TestValidCasts(Action castMethod)
        {
            castMethod();
        }

        [TestCaseSource(nameof(SimpleValueInvalidCasts))]
        public void TestInvalidCasts(Action castMethod)
        {
            castMethod();
        }
        
        public static IEnumerable<TestCaseData> SimpleValueValidCasts => CastSamples.GetValidCasts(typeof(SimpleValue));

        public static IEnumerable<TestCaseData> SimpleValueInvalidCasts => CastSamples.GetInvalidCasts(typeof(SimpleValue));
    }
}