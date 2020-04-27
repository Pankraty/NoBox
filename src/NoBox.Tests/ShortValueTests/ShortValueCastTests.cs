using NUnit.Framework;
using Pankraty.NoBox.Tests.Common;
using System;
using System.Collections.Generic;

namespace Pankraty.NoBox.Tests.ShortValueTests
{
    /// <summary>
    /// Test casts of <see cref="ShortValue"/> created from different clr types to all supported CLR types.
    /// Actual test cases are defined in <see cref="CastSamples"/> to keep them all in one place.
    /// "Id" of the test case corresponds to the line it is defined at.
    /// </summary>
    public class ShortValueCastTests
    {
        [TestCaseSource(nameof(ShortValueValidCasts))]
        public void TestValidCasts(Action castMethod)
        {
            castMethod();
        }

        [TestCaseSource(nameof(ShortValueInvalidCasts))]
        public void TestInvalidCasts(Action castMethod)
        {
            castMethod();
        }
        
        public static IEnumerable<TestCaseData> ShortValueValidCasts => CastSamples.GetValidCasts(typeof(ShortValue));

        public static IEnumerable<TestCaseData> ShortValueInvalidCasts => CastSamples.GetInvalidCasts(typeof(ShortValue));
    }
}