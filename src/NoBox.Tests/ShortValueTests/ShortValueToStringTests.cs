using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

namespace Pankraty.NoBox.Tests.ShortValueTests
{
    public class ShortValueToStringTests
    {
        [TestCaseSource(nameof(ToStringSource))]
        public void CanConvertToString(ShortValue value, string expectedValue)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");

            var actualValue = value.ToString();

            Assert.AreEqual(expectedValue, actualValue);
        }

        private static IEnumerable<TestCaseData> ToStringSource
        {
            get
            {
                yield return new TestCaseData((ShortValue) (bool) true, "True");
                yield return new TestCaseData((ShortValue) (sbyte) 1, "1");
                yield return new TestCaseData((ShortValue) (byte) 2, "2");
                yield return new TestCaseData((ShortValue) (short) 3000, "3000");
                yield return new TestCaseData((ShortValue) (ushort) 4000, "4000");
                yield return new TestCaseData((ShortValue) (int) 5000, "5000");
                yield return new TestCaseData((ShortValue) (uint) 6000, "6000");
                yield return new TestCaseData((ShortValue) (long) 7000, "7000");
                yield return new TestCaseData((ShortValue) (ulong) 8000, "8000");
                yield return new TestCaseData((ShortValue) (float) 9000.5, "9000.5");
                yield return new TestCaseData((ShortValue) (double) 10000.5, "10000.5");
                yield return new TestCaseData((ShortValue) (char) 'A', "A");
                yield return new TestCaseData((ShortValue) new DateTime(2020, 01, 01), "1/1/2020 12:00:00 AM");
                yield return new TestCaseData((ShortValue) TimeSpan.FromHours(1), "01:00:00");
            }
        }

        [TestCaseSource(nameof(ToStringWithCultureSource))]
        public void CanConvertToStringWithCulture(ShortValue value, string expectedValue)
        {
            var actualValue = value.ToString(CultureInfo.GetCultureInfo("ru-RU"));

            Assert.AreEqual(expectedValue, actualValue);
        }

        private static IEnumerable<TestCaseData> ToStringWithCultureSource
        {
            get
            {
                yield return new TestCaseData((ShortValue) (bool) true, "True");
                yield return new TestCaseData((ShortValue) (sbyte) 1, "1");
                yield return new TestCaseData((ShortValue) (byte) 2, "2");
                yield return new TestCaseData((ShortValue) (short) 3000, "3000");
                yield return new TestCaseData((ShortValue) (ushort) 4000, "4000");
                yield return new TestCaseData((ShortValue) (int) 5000, "5000");
                yield return new TestCaseData((ShortValue) (uint) 6000, "6000");
                yield return new TestCaseData((ShortValue) (long) 7000, "7000");
                yield return new TestCaseData((ShortValue) (ulong) 8000, "8000");
                yield return new TestCaseData((ShortValue) (float) 9000.5, "9000,5");
                yield return new TestCaseData((ShortValue) (double) 10000.5, "10000,5");
                yield return new TestCaseData((ShortValue) (char) 'A', "A");
                yield return new TestCaseData((ShortValue) new DateTime(2020, 01, 01), "01.01.2020 0:00:00");
                yield return new TestCaseData((ShortValue) TimeSpan.FromHours(1), "01:00:00");
            }
        }

        [TestCaseSource(nameof(ToStringWithFormatAndCultureSource))]
        public void CanConvertToStringWithFormatAndCulture(ShortValue value, string format, string expectedValue)
        {
            var actualValue = value.ToString(format, CultureInfo.GetCultureInfo("ru-RU"));

            Assert.AreEqual(expectedValue, actualValue);
        }

        private static IEnumerable<TestCaseData> ToStringWithFormatAndCultureSource
        {
            get
            {
                yield return new TestCaseData((ShortValue) (bool) true, "g", "True");
                yield return new TestCaseData((ShortValue) (sbyte) 1, "g", "1");
                yield return new TestCaseData((ShortValue) (byte) 2, "g", "2");
                yield return new TestCaseData((ShortValue) (short) 3000, "N2", "3 000,00");
                yield return new TestCaseData((ShortValue) (ushort) 4000, "N2", "4 000,00");
                yield return new TestCaseData((ShortValue) (int) 5000, "N2", "5 000,00");
                yield return new TestCaseData((ShortValue) (uint) 6000, "N2", "6 000,00");
                yield return new TestCaseData((ShortValue) (long) 7000, "N2", "7 000,00");
                yield return new TestCaseData((ShortValue) (ulong) 8000, "N2", "8 000,00");
                yield return new TestCaseData((ShortValue) (float) 9000.5, "N2", "9 000,50");
                yield return new TestCaseData((ShortValue) (double) 10000.5, "N2", "10 000,50");
                yield return new TestCaseData((ShortValue) (char) 'A', "g", "A");
                yield return new TestCaseData((ShortValue) new DateTime(2020, 01, 01), "g", "01.01.2020 0:00");
                yield return new TestCaseData((ShortValue) TimeSpan.FromHours(1), "g", "1:00:00");
            }
        }


        [TestCaseSource(nameof(ToStringWithFormatAndCultureSource))]
        public void CanConvertToStringWithFormat(ShortValue value, string format, string expectedValue)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("ru-RU");
            var actualValue = value.ToString(format);

            Assert.AreEqual(expectedValue, actualValue);
        }
    }
}