using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

namespace Pankraty.NoBox.Tests.SimpleValueTests
{
    public class SimpleValueToStringTests
    {
        [TestCaseSource(nameof(ToStringSource))]
        public void CanConvertToString(SimpleValue value, string expectedValue)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");

            var actualValue = value.ToString();

            Assert.AreEqual(expectedValue, actualValue);
        }

        private static IEnumerable<TestCaseData> ToStringSource
        {
            get
            {
                yield return new TestCaseData((SimpleValue) (bool) true, "True");
                yield return new TestCaseData((SimpleValue) (sbyte) 1, "1");
                yield return new TestCaseData((SimpleValue) (byte) 2, "2");
                yield return new TestCaseData((SimpleValue) (short) 3000, "3000");
                yield return new TestCaseData((SimpleValue) (ushort) 4000, "4000");
                yield return new TestCaseData((SimpleValue) (int) 5000, "5000");
                yield return new TestCaseData((SimpleValue) (uint) 6000, "6000");
                yield return new TestCaseData((SimpleValue) (long) 7000, "7000");
                yield return new TestCaseData((SimpleValue) (ulong) 8000, "8000");
                yield return new TestCaseData((SimpleValue) (float) 9000.5, "9000.5");
                yield return new TestCaseData((SimpleValue) (double) 10000.5, "10000.5");
                yield return new TestCaseData((SimpleValue) (decimal) 11000.5m, "11000.5");
                yield return new TestCaseData((SimpleValue) (char) 'A', "A");
                yield return new TestCaseData((SimpleValue) new DateTime(2020, 01, 01), "1/1/2020 12:00:00 AM");
                yield return new TestCaseData((SimpleValue) new DateTimeOffset(new DateTime(2020, 01, 01), TimeSpan.FromHours(2)), "1/1/2020 12:00:00 AM +02:00");
                yield return new TestCaseData((SimpleValue) TimeSpan.FromHours(1), "01:00:00");
                yield return new TestCaseData((SimpleValue) Guid.Parse("3F48D68D-3DB5-47D5-BFEB-1671B9C1726D"), "3f48d68d-3db5-47d5-bfeb-1671b9c1726d");
            }
        }

        [TestCaseSource(nameof(ToStringWithCultureSource))]
        public void CanConvertToStringWithCulture(SimpleValue value, string expectedValue)
        {
            var actualValue = value.ToString(CultureInfo.GetCultureInfo("ru-RU"));

            Assert.AreEqual(expectedValue, actualValue);
        }

        private static IEnumerable<TestCaseData> ToStringWithCultureSource
        {
            get
            {
                yield return new TestCaseData((SimpleValue) (bool) true, "True");
                yield return new TestCaseData((SimpleValue) (sbyte) 1, "1");
                yield return new TestCaseData((SimpleValue) (byte) 2, "2");
                yield return new TestCaseData((SimpleValue) (short) 3000, "3000");
                yield return new TestCaseData((SimpleValue) (ushort) 4000, "4000");
                yield return new TestCaseData((SimpleValue) (int) 5000, "5000");
                yield return new TestCaseData((SimpleValue) (uint) 6000, "6000");
                yield return new TestCaseData((SimpleValue) (long) 7000, "7000");
                yield return new TestCaseData((SimpleValue) (ulong) 8000, "8000");
                yield return new TestCaseData((SimpleValue) (float) 9000.5, "9000,5");
                yield return new TestCaseData((SimpleValue) (double) 10000.5, "10000,5");
                yield return new TestCaseData((SimpleValue) (decimal) 11000.5m, "11000,5");
                yield return new TestCaseData((SimpleValue) (char) 'A', "A");
                yield return new TestCaseData((SimpleValue) new DateTime(2020, 01, 01), "01.01.2020 0:00:00");
                yield return new TestCaseData((SimpleValue)new DateTimeOffset(new DateTime(2020, 01, 01), TimeSpan.FromHours(2)), "01.01.2020 0:00:00 +02:00");
                yield return new TestCaseData((SimpleValue) TimeSpan.FromHours(1), "01:00:00");
                yield return new TestCaseData((SimpleValue)Guid.Parse("F31BCC88-FF2B-4CF7-8A02-7E74BD508D83"), "f31bcc88-ff2b-4cf7-8a02-7e74bd508d83");
            }
        }

        [TestCaseSource(nameof(ToStringWithFormatAndCultureSource))]
        public void CanConvertToStringWithFormatAndCulture(SimpleValue value, string format, string expectedValue)
        {
            var actualValue = value.ToString(format, CultureInfo.GetCultureInfo("ru-RU"));

            Assert.AreEqual(expectedValue, actualValue);
        }

        private static IEnumerable<TestCaseData> ToStringWithFormatAndCultureSource
        {
            get
            {
                yield return new TestCaseData((SimpleValue) (bool) true, "g", "True");
                yield return new TestCaseData((SimpleValue) (sbyte) 1, "g", "1");
                yield return new TestCaseData((SimpleValue) (byte) 2, "g", "2");
                yield return new TestCaseData((SimpleValue) (short) 3000, "N2", "3 000,00");
                yield return new TestCaseData((SimpleValue) (ushort) 4000, "N2", "4 000,00");
                yield return new TestCaseData((SimpleValue) (int) 5000, "N2", "5 000,00");
                yield return new TestCaseData((SimpleValue) (uint) 6000, "N2", "6 000,00");
                yield return new TestCaseData((SimpleValue) (long) 7000, "N2", "7 000,00");
                yield return new TestCaseData((SimpleValue) (ulong) 8000, "N2", "8 000,00");
                yield return new TestCaseData((SimpleValue) (float) 9000.5, "N2", "9 000,50");
                yield return new TestCaseData((SimpleValue) (double) 10000.5, "N2", "10 000,50");
                yield return new TestCaseData((SimpleValue) (decimal) 11000.5m, "N2", "11 000,50");
                yield return new TestCaseData((SimpleValue) (char) 'A', "g", "A");
                yield return new TestCaseData((SimpleValue) new DateTime(2020, 01, 01), "g", "01.01.2020 0:00");
                yield return new TestCaseData((SimpleValue)new DateTimeOffset(new DateTime(2020, 01, 01), TimeSpan.FromHours(2)), "dddd, MMM dd yyyy HH:mm:ss zzz", "среда, янв 01 2020 00:00:00 +02:00");
                yield return new TestCaseData((SimpleValue) TimeSpan.FromHours(1), "g", "1:00:00");
                yield return new TestCaseData((SimpleValue) Guid.Parse("C28AFE16-87B3-4A82-9830-BA8C9D0D63F8"), "N", "c28afe1687b34a829830ba8c9d0d63f8");
            }
        }


        [TestCaseSource(nameof(ToStringWithFormatAndCultureSource))]
        public void CanConvertToStringWithFormat(SimpleValue value, string format, string expectedValue)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("ru-RU");
            var actualValue = value.ToString(format);

            Assert.AreEqual(expectedValue, actualValue);
        }
    }
}