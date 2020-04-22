using NUnit.Framework;
using Pankraty.NoBox;
using System;

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
    }
}