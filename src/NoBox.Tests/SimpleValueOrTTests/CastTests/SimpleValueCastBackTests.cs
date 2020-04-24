using NUnit.Framework;
using System;

namespace Pankraty.NoBox.Tests.SimpleValueOrTTests.CastTests
{
    using SimpleValueOrString = SimpleValueOr<String>;

    public class SimpleValueOrStringCastBackTests : TheoryTestBase
    {
        [Theory]
        public void CanCastBackToBool(bool value)
        {
            SimpleValueOrString s = value;
            var actualValue = (bool) s;
            Assert.AreEqual(value, actualValue);
        }

        [Theory]
        public void CanCastBackToByte(byte value)
        {
            SimpleValueOrString s = value;
            var actualValue = (byte) s;
            Assert.AreEqual(value, actualValue);
        }

        [Theory]
        public void CanCastBackToChar(char value)
        {
            SimpleValueOrString s = value;
            var actualValue = (char) s;
            Assert.AreEqual(value, actualValue);
        }

        [Theory]
        public void CanCastBackToDateTime(DateTime value)
        {
            SimpleValueOrString s = value;
            var actualValue = (DateTime) s;
            Assert.AreEqual(value, actualValue);
        }

        [Theory]
        public void CanCastBackToDecimal(decimal value)
        {
            SimpleValueOrString s = value;
            var actualValue = (decimal) s;
            Assert.AreEqual(value, actualValue);
        }

        [Theory]
        public void CanCastBackToDouble(double value)
        {
            SimpleValueOrString s = value;
            var actualValue = (double) s;
            Assert.AreEqual(value, actualValue);
        }

        [Theory]
        public void CanCastBackToFloat(float value)
        {
            SimpleValueOrString s = value;
            var actualValue = (float) s;
            Assert.AreEqual(value, actualValue);
        }

        [Theory]
        public void CanCastBackToInt(int value)
        {
            SimpleValueOrString s = value;
            var actualValue = (int) s;
            Assert.AreEqual(value, actualValue);
        }

        [Theory]
        public void CanCastBackToLong(long value)
        {
            SimpleValueOrString s = value;
            var actualValue = (long) s;
            Assert.AreEqual(value, actualValue);
        }

        [Theory]
        public void CanCastBackToSByte(sbyte value)
        {
            SimpleValueOrString s = value;
            var actualValue = (sbyte) s;
            Assert.AreEqual(value, actualValue);
        }

        [Theory]
        public void CanCastBackToShort(short value)
        {
            SimpleValueOrString s = value;
            var actualValue = (short) s;
            Assert.AreEqual(value, actualValue);
        }

        [Theory]
        public void CanCastBackToTimeSpan(TimeSpan value)
        {
            SimpleValueOrString s = value;
            var actualValue = (TimeSpan) s;
            Assert.AreEqual(value, actualValue);
        }

        [Theory]
        public void CanCastBackToUInt(uint value)
        {
            SimpleValueOrString s = value;
            var actualValue = (uint) s;
            Assert.AreEqual(value, actualValue);
        }

        [Theory]
        public void CanCastBackToULong(ulong value)
        {
            SimpleValueOrString s = value;
            var actualValue = (ulong) s;
            Assert.AreEqual(value, actualValue);
        }

        [Theory]
        public void CanCastBackToUShort(ushort value)
        {
            SimpleValueOrString s = value;
            var actualValue = (ushort) s;
            Assert.AreEqual(value, actualValue);
        }
    }
}