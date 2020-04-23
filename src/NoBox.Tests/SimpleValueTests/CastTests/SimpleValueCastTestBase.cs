using NUnit.Framework;
using Pankraty.NoBox;
using System;
using System.Collections.Generic;

namespace NoBox.Tests.SimpleValueTests.CastTests
{
    public abstract class SimpleValueCastTestBase
    {
        public static IEnumerable<TestCaseData> CastNumberInvalidSources
        {
            get
            {
                yield return new TestCaseData(new Func<SimpleValue, bool    >(v => v));
                yield return new TestCaseData(new Func<SimpleValue, char    >(v => v));
                yield return new TestCaseData(new Func<SimpleValue, DateTime>(v => v));
                yield return new TestCaseData(new Func<SimpleValue, TimeSpan>(v => v));
            }
        }
    }
}