using NUnit.Framework;
using System;

namespace Pankraty.NoBox.Tests.ShortValueTests
{
    public class ShortValueCreateTests : TheoryTestBase
    {
        [Test]
        public void CheckSize()
        {
            //Protect from adding new fields that are too large
            unsafe
            {
                var size = sizeof(ShortValue);
                Assert.AreEqual(12, size);
            }
        }

        [Theory]
        public void CanCreateShortValue_FromBool(bool value)
        {
            ShortValue s = value;
            Assert.AreEqual(SimpleValueType.Bool, s.ValueType);
        }

        [Theory]
        public void CanCreateShortValue_FromByte(byte value)
        {
            ShortValue s = value;
            Assert.AreEqual(SimpleValueType.Byte, s.ValueType);
        }

        [Theory]
        public void CanCreateShortValue_FromChar(char value)
        {
            ShortValue s = value;
            Assert.AreEqual(SimpleValueType.Char, s.ValueType);
        }

        [Theory]
        public void CanCreateShortValue_FromDateTime(DateTime value)
        {
            ShortValue s = value;
            Assert.AreEqual(SimpleValueType.DateTime, s.ValueType);
        }

        [Theory]
        public void CanCreateShortValue_FromDouble(double value)
        {
            ShortValue s = value;
            Assert.AreEqual(SimpleValueType.Double, s.ValueType);
        }

        [Theory]
        public void CanCreateShortValue_FromFloat(float value)
        {
            ShortValue s = value;
            Assert.AreEqual(SimpleValueType.Float, s.ValueType);
        }

        [Theory]
        public void CanCreateShortValue_FromInt(int value)
        {
            ShortValue s = value;
            Assert.AreEqual(SimpleValueType.Int, s.ValueType);
        }

        [Theory]
        public void CanCreateShortValue_FromLong(long value)
        {
            ShortValue s = value;
            Assert.AreEqual(SimpleValueType.Long, s.ValueType);
        }

        [Theory]
        public void CanCreateShortValue_FromSByte(sbyte value)
        {
            ShortValue s = value;
            Assert.AreEqual(SimpleValueType.SByte, s.ValueType);
        }

        [Theory]
        public void CanCreateShortValue_FromShort(short value)
        {
            ShortValue s = value;
            Assert.AreEqual(SimpleValueType.Short, s.ValueType);
        }

        [Theory]
        public void CanCreateShortValue_FromTimeSpan(TimeSpan value)
        {
            ShortValue s = value;
            Assert.AreEqual(SimpleValueType.TimeSpan, s.ValueType);
        }

        [Theory]
        public void CanCreateShortValue_FromUInt(uint value)
        {
            ShortValue s = value;
            Assert.AreEqual(SimpleValueType.UInt, s.ValueType);
        }

        [Theory]
        public void CanCreateShortValue_FromULong(ulong value)
        {
            ShortValue s = value;
            Assert.AreEqual(SimpleValueType.ULong, s.ValueType);
        }

        [Theory]
        public void CanCreateShortValue_FromUShort(ushort value)
        {
            ShortValue s = value;
            Assert.AreEqual(SimpleValueType.UShort, s.ValueType);
        }
    }
}