using NUnit.Framework;
using Pankraty.NoBox;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

namespace NoBox.Tests
{
    public class SimpleValueTests : TheoryTestBase
    {
        #region Create

        [Theory]
        public void CanCreateSimpleValue_FromBool(bool value)
        {
            SimpleValue s = value;
            Assert.AreEqual(SimpleValueType.Bool, s.ValueType);
        }

        [Theory]
        public void CanCreateSimpleValue_FromByte(byte value)
        {
            SimpleValue s = value;
            Assert.AreEqual(SimpleValueType.Byte, s.ValueType);
        }

        [Theory]
        public void CanCreateSimpleValue_FromChar(char value)
        {
            SimpleValue s = value;
            Assert.AreEqual(SimpleValueType.Char, s.ValueType);
        }

        [Theory]
        public void CanCreateSimpleValue_FromDateTime(DateTime value)
        {
            SimpleValue s = value;
            Assert.AreEqual(SimpleValueType.DateTime, s.ValueType);
        }

        [Theory]
        public void CanCreateSimpleValue_FromDecimal(decimal value)
        {
            SimpleValue s = value;
            Assert.AreEqual(SimpleValueType.Decimal, s.ValueType);
        }

        [Theory]
        public void CanCreateSimpleValue_FromDouble(double value)
        {
            SimpleValue s = value;
            Assert.AreEqual(SimpleValueType.Double, s.ValueType);
        }

        [Theory]
        public void CanCreateSimpleValue_FromFloat(float value)
        {
            SimpleValue s = value;
            Assert.AreEqual(SimpleValueType.Float, s.ValueType);
        }

        [Theory]
        public void CanCreateSimpleValue_FromInt(int value)
        {
            SimpleValue s = value;
            Assert.AreEqual(SimpleValueType.Int, s.ValueType);
        }

        [Theory]
        public void CanCreateSimpleValue_FromLong(long value)
        {
            SimpleValue s = value;
            Assert.AreEqual(SimpleValueType.Long, s.ValueType);
        }

        [Theory]
        public void CanCreateSimpleValue_FromSByte(sbyte value)
        {
            SimpleValue s = value;
            Assert.AreEqual(SimpleValueType.SByte, s.ValueType);
        }

        [Theory]
        public void CanCreateSimpleValue_FromShort(short value)
        {
            SimpleValue s = value;
            Assert.AreEqual(SimpleValueType.Short, s.ValueType);
        }

        [Theory]
        public void CanCreateSimpleValue_FromTimeSpan(TimeSpan value)
        {
            SimpleValue s = value;
            Assert.AreEqual(SimpleValueType.TimeSpan, s.ValueType);
        }

        [Theory]
        public void CanCreateSimpleValue_FromUInt(uint value)
        {
            SimpleValue s = value;
            Assert.AreEqual(SimpleValueType.UInt, s.ValueType);
        }

        [Theory]
        public void CanCreateSimpleValue_FromULong(ulong value)
        {
            SimpleValue s = value;
            Assert.AreEqual(SimpleValueType.ULong, s.ValueType);
        }

        [Theory]
        public void CanCreateSimpleValue_FromUShort(ushort value)
        {
            SimpleValue s = value;
            Assert.AreEqual(SimpleValueType.UShort, s.ValueType);
        }

        #endregion Create

        #region Cast Back

        [Theory]
        public void CanCastBackToBool(bool value)
        {
            SimpleValue s = value;
            var actualValue = (bool)s;
            Assert.AreEqual(value, actualValue);
        }

        [Theory]
        public void CanCastBackToByte(byte value)
        {
            SimpleValue s = value;
            var actualValue = (byte)s;
            Assert.AreEqual(value, actualValue);
        }

        [Theory]
        public void CanCastBackToChar(char value)
        {
            SimpleValue s = value;
            var actualValue = (char)s;
            Assert.AreEqual(value, actualValue);
        }

        [Theory]
        public void CanCastBackToDateTime(DateTime value)
        {
            SimpleValue s = value;
            var actualValue = (DateTime)s;
            Assert.AreEqual(value, actualValue);
        }

        [Theory]
        public void CanCastBackToDecimal(decimal value)
        {
            SimpleValue s = value;
            var actualValue = (decimal)s;
            Assert.AreEqual(value, actualValue);
        }

        [Theory]
        public void CanCastBackToDouble(double value)
        {
            SimpleValue s = value;
            var actualValue = (double)s;
            Assert.AreEqual(value, actualValue);
        }

        [Theory]
        public void CanCastBackToFloat(float value)
        {
            SimpleValue s = value;
            var actualValue = (float)s;
            Assert.AreEqual(value, actualValue);
        }

        [Theory]
        public void CanCastBackToInt(int value)
        {
            SimpleValue s = value;
            var actualValue = (int)s;
            Assert.AreEqual(value, actualValue);
        }

        [Theory]
        public void CanCastBackToLong(long value)
        {
            SimpleValue s = value;
            var actualValue = (long)s;
            Assert.AreEqual(value, actualValue);
        }

        [Theory]
        public void CanCastBackToSByte(sbyte value)
        {
            SimpleValue s = value;
            var actualValue = (sbyte)s;
            Assert.AreEqual(value, actualValue);
        }

        [Theory]
        public void CanCastBackToShort(short value)
        {
            SimpleValue s = value;
            var actualValue = (short)s;
            Assert.AreEqual(value, actualValue);
        }

        [Theory]
        public void CanCastBackToTimeSpan(TimeSpan value)
        {
            SimpleValue s = value;
            var actualValue = (TimeSpan)s;
            Assert.AreEqual(value, actualValue);
        }

        [Theory]
        public void CanCastBackToUInt(uint value)
        {
            SimpleValue s = value;
            var actualValue = (uint)s;
            Assert.AreEqual(value, actualValue);
        }

        [Theory]
        public void CanCastBackToULong(ulong value)
        {
            SimpleValue s = value;
            var actualValue = (ulong)s;
            Assert.AreEqual(value, actualValue);
        }

        [Theory]
        public void CanCastBackToUShort(ushort value)
        {
            SimpleValue s = value;
            var actualValue = (ushort)s;
            Assert.AreEqual(value, actualValue);
        }

        #endregion Cast Back

        #region ToString

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
                yield return new TestCaseData((SimpleValue) (bool)true                , "True");
                yield return new TestCaseData((SimpleValue) (sbyte)1                  , "1");
                yield return new TestCaseData((SimpleValue) (byte)2                   , "2");
                yield return new TestCaseData((SimpleValue) (short)3000               , "3000");
                yield return new TestCaseData((SimpleValue) (ushort)4000              , "4000");
                yield return new TestCaseData((SimpleValue) (int)5000                 , "5000");
                yield return new TestCaseData((SimpleValue) (uint)6000                , "6000");
                yield return new TestCaseData((SimpleValue) (long)7000                , "7000");
                yield return new TestCaseData((SimpleValue) (ulong)8000               , "8000");
                yield return new TestCaseData((SimpleValue) (float)9000.5             , "9000.5");
                yield return new TestCaseData((SimpleValue) (double)10000.5           , "10000.5");
                yield return new TestCaseData((SimpleValue) (decimal) 11000.5m        , "11000.5");
                yield return new TestCaseData((SimpleValue) (char)'A'                 , "A");
                yield return new TestCaseData((SimpleValue) new DateTime(2020, 01, 01), "1/1/2020 12:00:00 AM");
                yield return new TestCaseData((SimpleValue) TimeSpan.FromHours(1)     , "01:00:00");
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
                yield return new TestCaseData((SimpleValue) (bool)true                , "True");
                yield return new TestCaseData((SimpleValue) (sbyte)1                  , "1");
                yield return new TestCaseData((SimpleValue) (byte)2                   , "2");
                yield return new TestCaseData((SimpleValue) (short)3000               , "3000");
                yield return new TestCaseData((SimpleValue) (ushort)4000              , "4000");
                yield return new TestCaseData((SimpleValue) (int)5000                 , "5000");
                yield return new TestCaseData((SimpleValue) (uint)6000                , "6000");
                yield return new TestCaseData((SimpleValue) (long)7000                , "7000");
                yield return new TestCaseData((SimpleValue) (ulong)8000               , "8000");
                yield return new TestCaseData((SimpleValue) (float)9000.5             , "9000,5");
                yield return new TestCaseData((SimpleValue) (double)10000.5           , "10000,5");
                yield return new TestCaseData((SimpleValue) (decimal) 11000.5m        , "11000,5");
                yield return new TestCaseData((SimpleValue) (char)'A'                 , "A");
                yield return new TestCaseData((SimpleValue) new DateTime(2020, 01, 01), "01.01.2020 0:00:00");
                yield return new TestCaseData((SimpleValue) TimeSpan.FromHours(1)     , "01:00:00");
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
                yield return new TestCaseData((SimpleValue) (bool)true                , "g", "True");
                yield return new TestCaseData((SimpleValue) (sbyte)1                  , "g", "1");
                yield return new TestCaseData((SimpleValue) (byte)2                   , "g", "2");
                yield return new TestCaseData((SimpleValue) (short)3000               , "N2", "3 000,00");
                yield return new TestCaseData((SimpleValue) (ushort)4000              , "N2", "4 000,00");
                yield return new TestCaseData((SimpleValue) (int)5000                 , "N2", "5 000,00");
                yield return new TestCaseData((SimpleValue) (uint)6000                , "N2", "6 000,00");
                yield return new TestCaseData((SimpleValue) (long)7000                , "N2", "7 000,00");
                yield return new TestCaseData((SimpleValue) (ulong)8000               , "N2", "8 000,00");
                yield return new TestCaseData((SimpleValue) (float)9000.5             , "N2", "9 000,50");
                yield return new TestCaseData((SimpleValue) (double)10000.5           , "N2", "10 000,50");
                yield return new TestCaseData((SimpleValue) (decimal) 11000.5m        , "N2", "11 000,50");
                yield return new TestCaseData((SimpleValue) (char)'A'                 , "g", "A");
                yield return new TestCaseData((SimpleValue) new DateTime(2020, 01, 01), "g", "01.01.2020 0:00");
                yield return new TestCaseData((SimpleValue) TimeSpan.FromHours(1)     , "g", "1:00:00");
            }
        }


        [TestCaseSource(nameof(ToStringWithFormatAndCultureSource))]
        public void CanConvertToStringWithFormat(SimpleValue value, string format, string expectedValue)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("ru-RU");
            var actualValue = value.ToString(format);

            Assert.AreEqual(expectedValue, actualValue);
        }

        #endregion ToString
        
        #region IsNumber

        [TestCaseSource(nameof(IsNumberSource))]
        public bool TestIsNumber(SimpleValue value)
        {
            return value.IsNumber();
        }

        private static IEnumerable<TestCaseData> IsNumberSource
        {
            get
            {
                yield return new TestCaseData((SimpleValue)(bool)true).Returns(false);
                yield return new TestCaseData((SimpleValue)(sbyte)1).Returns(true);
                yield return new TestCaseData((SimpleValue)(byte)2).Returns(true);
                yield return new TestCaseData((SimpleValue)(short)3000).Returns(true);
                yield return new TestCaseData((SimpleValue)(ushort)4000).Returns(true);
                yield return new TestCaseData((SimpleValue)(int)5000).Returns(true);
                yield return new TestCaseData((SimpleValue)(uint)6000).Returns(true);
                yield return new TestCaseData((SimpleValue)(long)7000).Returns(true);
                yield return new TestCaseData((SimpleValue)(ulong)8000).Returns(true);
                yield return new TestCaseData((SimpleValue)(float)9000.5).Returns(true);
                yield return new TestCaseData((SimpleValue)(double)10000.5).Returns(true);
                yield return new TestCaseData((SimpleValue)(decimal)11000.5m).Returns(true);
                yield return new TestCaseData((SimpleValue)(char)'A').Returns(false);
                yield return new TestCaseData((SimpleValue)new DateTime(2020, 01, 01)).Returns(false);
                yield return new TestCaseData((SimpleValue)TimeSpan.FromHours(1)).Returns(false);
            }
        }

        #endregion IsNumber
    }
}