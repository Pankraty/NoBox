using NUnit.Framework;
using Pankraty.NoBox;
using System;

namespace NoBox.Tests.SimpleValueTests.CastTests
{
    public class SimpleValueCastBackTests : TheoryTestBase
    {
        [Theory]
        public void CanCastBackToBool(bool value)
        {
            SimpleValue s = value;
            var actualValue = (bool) s;
            Assert.AreEqual(value, actualValue);
        }

        [Theory]
        public void CanCastBackToByte(byte value)
        {
            SimpleValue s = value;
            var actualValue = (byte) s;
            Assert.AreEqual(value, actualValue);
        }

        [Theory]
        public void CanCastBackToChar(char value)
        {
            SimpleValue s = value;
            var actualValue = (char) s;
            Assert.AreEqual(value, actualValue);
        }

        [Theory]
        public void CanCastBackToDateTime(DateTime value)
        {
            SimpleValue s = value;
            var actualValue = (DateTime) s;
            Assert.AreEqual(value, actualValue);
        }

        [Theory]
        public void CanCastBackToDecimal(decimal value)
        {
            SimpleValue s = value;
            var actualValue = (decimal) s;
            Assert.AreEqual(value, actualValue);
        }

        [Theory]
        public void CanCastBackToDouble(double value)
        {
            SimpleValue s = value;
            var actualValue = (double) s;
            Assert.AreEqual(value, actualValue);
        }

        [Theory]
        public void CanCastBackToFloat(float value)
        {
            SimpleValue s = value;
            var actualValue = (float) s;
            Assert.AreEqual(value, actualValue);
        }

        [Theory]
        public void CanCastBackToInt(int value)
        {
            SimpleValue s = value;
            var actualValue = (int) s;
            Assert.AreEqual(value, actualValue);
        }

        [Theory]
        public void CanCastBackToLong(long value)
        {
            SimpleValue s = value;
            var actualValue = (long) s;
            Assert.AreEqual(value, actualValue);
        }

        [Theory]
        public void CanCastBackToSByte(sbyte value)
        {
            SimpleValue s = value;
            var actualValue = (sbyte) s;
            Assert.AreEqual(value, actualValue);
        }

        [Theory]
        public void CanCastBackToShort(short value)
        {
            SimpleValue s = value;
            var actualValue = (short) s;
            Assert.AreEqual(value, actualValue);
        }

        [Theory]
        public void CanCastBackToTimeSpan(TimeSpan value)
        {
            SimpleValue s = value;
            var actualValue = (TimeSpan) s;
            Assert.AreEqual(value, actualValue);
        }

        [Theory]
        public void CanCastBackToUInt(uint value)
        {
            SimpleValue s = value;
            var actualValue = (uint) s;
            Assert.AreEqual(value, actualValue);
        }

        [Theory]
        public void CanCastBackToULong(ulong value)
        {
            SimpleValue s = value;
            var actualValue = (ulong) s;
            Assert.AreEqual(value, actualValue);
        }

        [Theory]
        public void CanCastBackToUShort(ushort value)
        {
            SimpleValue s = value;
            var actualValue = (ushort) s;
            Assert.AreEqual(value, actualValue);
        }
    }
}