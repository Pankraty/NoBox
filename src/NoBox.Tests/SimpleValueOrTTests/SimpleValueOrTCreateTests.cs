using NUnit.Framework;
using Pankraty.NoBox;
using System;

namespace NoBox.Tests.SimpleValueOrTTests
{
    using SimpleValueOrString = SimpleValueOr<String>;

    public class SimpleValueOrTCreateTests : TheoryTestBase
    {
        [Theory]
        public void CanCreateSimpleValueOrString_FromBool(bool value)
        {
            SimpleValueOrString s = value;
            Assert.IsTrue(s.IsValue);
            Assert.AreEqual(SimpleValueType.Bool, s.Value.ValueType);
        }

        [Theory]
        public void CanCreateSimpleValueOrString_FromByte(byte value)
        {
            SimpleValueOrString s = value;
            Assert.IsTrue(s.IsValue);
            Assert.AreEqual(SimpleValueType.Byte, s.Value.ValueType);
        }

        [Theory]
        public void CanCreateSimpleValueOrString_FromChar(char value)
        {
            SimpleValueOrString s = value;
            Assert.IsTrue(s.IsValue);
            Assert.AreEqual(SimpleValueType.Char, s.Value.ValueType);
        }

        [Theory]
        public void CanCreateSimpleValueOrString_FromDateTime(DateTime value)
        {
            SimpleValueOrString s = value;
            Assert.IsTrue(s.IsValue);
            Assert.AreEqual(SimpleValueType.DateTime, s.Value.ValueType);
        }

        [Theory]
        public void CanCreateSimpleValueOrString_FromDateTimeOffset(DateTimeOffset value)
        {
            SimpleValueOrString s = value;
            Assert.IsTrue(s.IsValue);
            Assert.AreEqual(SimpleValueType.DateTimeOffset, s.Value.ValueType);
        }

        [Theory]
        public void CanCreateSimpleValueOrString_FromDecimal(decimal value)
        {
            SimpleValueOrString s = value;
            Assert.IsTrue(s.IsValue);
            Assert.AreEqual(SimpleValueType.Decimal, s.Value.ValueType);
        }

        [Theory]
        public void CanCreateSimpleValueOrString_FromDouble(double value)
        {
            SimpleValueOrString s = value;
            Assert.IsTrue(s.IsValue);
            Assert.AreEqual(SimpleValueType.Double, s.Value.ValueType);
        }

        [Theory]
        public void CanCreateSimpleValueOrString_FromFloat(float value)
        {
            SimpleValueOrString s = value;
            Assert.IsTrue(s.IsValue);
            Assert.AreEqual(SimpleValueType.Float, s.Value.ValueType);
        }

        [Theory]
        public void CanCreateSimpleValueOrString_FromGuid(Guid value)
        {
            SimpleValueOrString s = value;
            Assert.IsTrue(s.IsValue);
            Assert.AreEqual(SimpleValueType.Guid, s.Value.ValueType);
        }

        [Theory]
        public void CanCreateSimpleValueOrString_FromInt(int value)
        {
            SimpleValueOrString s = value;
            Assert.IsTrue(s.IsValue);
            Assert.AreEqual(SimpleValueType.Int, s.Value.ValueType);
        }

        [Theory]
        public void CanCreateSimpleValueOrString_FromLong(long value)
        {
            SimpleValueOrString s = value;
            Assert.IsTrue(s.IsValue);
            Assert.AreEqual(SimpleValueType.Long, s.Value.ValueType);
        }

        [Theory]
        public void CanCreateSimpleValueOrString_FromSByte(sbyte value)
        {
            SimpleValueOrString s = value;
            Assert.IsTrue(s.IsValue);
            Assert.AreEqual(SimpleValueType.SByte, s.Value.ValueType);
        }

        [Theory]
        public void CanCreateSimpleValueOrString_FromShort(short value)
        {
            SimpleValueOrString s = value;
            Assert.IsTrue(s.IsValue);
            Assert.AreEqual(SimpleValueType.Short, s.Value.ValueType);
        }

        [Theory]
        public void CanCreateSimpleValueOrString_FromTimeSpan(TimeSpan value)
        {
            SimpleValueOrString s = value;
            Assert.IsTrue(s.IsValue);
            Assert.AreEqual(SimpleValueType.TimeSpan, s.Value.ValueType);
        }

        [Theory]
        public void CanCreateSimpleValueOrString_FromUInt(uint value)
        {
            SimpleValueOrString s = value;
            Assert.IsTrue(s.IsValue);
            Assert.AreEqual(SimpleValueType.UInt, s.Value.ValueType);
        }

        [Theory]
        public void CanCreateSimpleValueOrString_FromULong(ulong value)
        {
            SimpleValueOrString s = value;
            Assert.IsTrue(s.IsValue);
            Assert.AreEqual(SimpleValueType.ULong, s.Value.ValueType);
        }

        [Theory]
        public void CanCreateSimpleValueOrString_FromUShort(ushort value)
        {
            SimpleValueOrString s = value;
            Assert.IsTrue(s.IsValue);
            Assert.AreEqual(SimpleValueType.UShort, s.Value.ValueType);
        }

        [Theory]
        public void CanCreateSimpleValueOrString_FromString(string value)
        {
            SimpleValueOrString s = value;
            Assert.IsFalse(s.IsValue);
            Assert.AreSame(value, s.Reference);
        }

        [Test]
        public void CanCreateSimpleValueOrString_FromNull()
        {
            SimpleValueOrString s = null;
            Assert.IsFalse(s.IsValue);
            Assert.IsNull(s.Reference);
        }
    }
}