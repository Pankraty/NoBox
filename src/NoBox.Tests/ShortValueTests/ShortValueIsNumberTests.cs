using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Pankraty.NoBox.Tests.ShortValueTests
{
    public class ShortValueIsNumberTests
    {
        [TestCaseSource(nameof(IsNumberSource))]
        public bool TestIsNumber(ShortValue value)
        {
            return value.IsNumber();
        }

        private static IEnumerable<TestCaseData> IsNumberSource
        {
            get
            {
                yield return new TestCaseData((ShortValue)(bool)true)                .Returns(false);
                yield return new TestCaseData((ShortValue)(sbyte)1)                  .Returns(true);
                yield return new TestCaseData((ShortValue)(byte)2)                   .Returns(true);
                yield return new TestCaseData((ShortValue)(short)3000)               .Returns(true);
                yield return new TestCaseData((ShortValue)(ushort)4000)              .Returns(true);
                yield return new TestCaseData((ShortValue)(int)5000)                 .Returns(true);
                yield return new TestCaseData((ShortValue)(uint)6000)                .Returns(true);
                yield return new TestCaseData((ShortValue)(long)7000)                .Returns(true);
                yield return new TestCaseData((ShortValue)(ulong)8000)               .Returns(true);
                yield return new TestCaseData((ShortValue)(float)9000.5)             .Returns(true);
                yield return new TestCaseData((ShortValue)(double)10000.5)           .Returns(true);
                yield return new TestCaseData((ShortValue)(char)'A')                 .Returns(false);
                yield return new TestCaseData((ShortValue)new DateTime(2020, 01, 01)).Returns(false);
                yield return new TestCaseData((ShortValue)TimeSpan.FromHours(1))     .Returns(false);
            }
        }
    }
}