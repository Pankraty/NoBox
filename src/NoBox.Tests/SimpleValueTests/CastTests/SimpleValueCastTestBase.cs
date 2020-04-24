using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Pankraty.NoBox.Tests.SimpleValueTests.CastTests
{
    public abstract class SimpleValueCastTestBase
    {
        public static IEnumerable<TestCaseData> CastNumberInvalidSources
        {
            get
            {
                yield return new TestCaseData(new Func<SimpleValue, bool          >(v => v));
                yield return new TestCaseData(new Func<SimpleValue, DateTime      >(v => v));
                yield return new TestCaseData(new Func<SimpleValue, DateTimeOffset>(v => v));
                yield return new TestCaseData(new Func<SimpleValue, TimeSpan      >(v => v));
                yield return new TestCaseData(new Func<SimpleValue, Guid          >(v => v));
            }
        }
    }
}