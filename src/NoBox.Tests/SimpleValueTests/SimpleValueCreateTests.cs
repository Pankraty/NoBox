using NUnit.Framework;
using Pankraty.NoBox;
using System;

namespace NoBox.Tests.SimpleValueTests
{
    public class SimpleValueCreateTests : TheoryTestBase
    {
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
    }
}