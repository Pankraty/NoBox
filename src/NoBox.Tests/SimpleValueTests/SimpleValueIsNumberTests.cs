using System;
using System.Collections.Generic;
using NUnit.Framework;
using Pankraty.NoBox;

namespace NoBox.Tests.SimpleValueTests
{
    public class SimpleValueIsNumberTests
    {
        [TestCaseSource(nameof(IsNumberSource))]
        public bool TestIsNumber(SimpleValue value)
        {
            return value.IsNumber();
        }

        private static IEnumerable<TestCaseData> IsNumberSource
        {
            get
            {
                yield return new TestCaseData((SimpleValue)(bool)true)                .Returns(false);
                yield return new TestCaseData((SimpleValue)(sbyte)1)                  .Returns(true);
                yield return new TestCaseData((SimpleValue)(byte)2)                   .Returns(true);
                yield return new TestCaseData((SimpleValue)(short)3000)               .Returns(true);
                yield return new TestCaseData((SimpleValue)(ushort)4000)              .Returns(true);
                yield return new TestCaseData((SimpleValue)(int)5000)                 .Returns(true);
                yield return new TestCaseData((SimpleValue)(uint)6000)                .Returns(true);
                yield return new TestCaseData((SimpleValue)(long)7000)                .Returns(true);
                yield return new TestCaseData((SimpleValue)(ulong)8000)               .Returns(true);
                yield return new TestCaseData((SimpleValue)(float)9000.5)             .Returns(true);
                yield return new TestCaseData((SimpleValue)(double)10000.5)           .Returns(true);
                yield return new TestCaseData((SimpleValue)(decimal)11000.5m)         .Returns(true);
                yield return new TestCaseData((SimpleValue)(char)'A')                 .Returns(false);
                yield return new TestCaseData((SimpleValue)new DateTime(2020, 01, 01)).Returns(false);
                yield return new TestCaseData((SimpleValue)TimeSpan.FromHours(1))     .Returns(false);
            }
        }
    }
}