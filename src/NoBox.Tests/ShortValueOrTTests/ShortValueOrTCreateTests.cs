using NUnit.Framework;
using System;

namespace Pankraty.NoBox.Tests.ShortValueOrTTests
{
    using ShortValueOrString = ShortValueOr<String>;

    public class ShortValueOrTCreateTests : TheoryTestBase
    {
        [Theory]
        public void CanCreateShortValueOrString_FromBool(bool value)
        {
            ShortValueOrString s = value;
            Assert.IsTrue(s.IsValue);
            Assert.AreEqual(SimpleValueType.Bool, s.Value.ValueType);
        }

        [Theory]
        public void CanCreateShortValueOrString_FromByte(byte value)
        {
            ShortValueOrString s = value;
            Assert.IsTrue(s.IsValue);
            Assert.AreEqual(SimpleValueType.Byte, s.Value.ValueType);
        }

        [Theory]
        public void CanCreateShortValueOrString_FromChar(char value)
        {
            ShortValueOrString s = value;
            Assert.IsTrue(s.IsValue);
            Assert.AreEqual(SimpleValueType.Char, s.Value.ValueType);
        }

        [Theory]
        public void CanCreateShortValueOrString_FromDateTime(DateTime value)
        {
            ShortValueOrString s = value;
            Assert.IsTrue(s.IsValue);
            Assert.AreEqual(SimpleValueType.DateTime, s.Value.ValueType);
        }

        [Theory]
        public void CanCreateShortValueOrString_FromDouble(double value)
        {
            ShortValueOrString s = value;
            Assert.IsTrue(s.IsValue);
            Assert.AreEqual(SimpleValueType.Double, s.Value.ValueType);
        }

        [Theory]
        public void CanCreateShortValueOrString_FromFloat(float value)
        {
            ShortValueOrString s = value;
            Assert.IsTrue(s.IsValue);
            Assert.AreEqual(SimpleValueType.Float, s.Value.ValueType);
        }

        [Theory]
        public void CanCreateShortValueOrString_FromInt(int value)
        {
            ShortValueOrString s = value;
            Assert.IsTrue(s.IsValue);
            Assert.AreEqual(SimpleValueType.Int, s.Value.ValueType);
        }

        [Theory]
        public void CanCreateShortValueOrString_FromLong(long value)
        {
            ShortValueOrString s = value;
            Assert.IsTrue(s.IsValue);
            Assert.AreEqual(SimpleValueType.Long, s.Value.ValueType);
        }

        [Theory]
        public void CanCreateShortValueOrString_FromSByte(sbyte value)
        {
            ShortValueOrString s = value;
            Assert.IsTrue(s.IsValue);
            Assert.AreEqual(SimpleValueType.SByte, s.Value.ValueType);
        }

        [Theory]
        public void CanCreateShortValueOrString_FromShort(short value)
        {
            ShortValueOrString s = value;
            Assert.IsTrue(s.IsValue);
            Assert.AreEqual(SimpleValueType.Short, s.Value.ValueType);
        }

        [Theory]
        public void CanCreateShortValueOrString_FromTimeSpan(TimeSpan value)
        {
            ShortValueOrString s = value;
            Assert.IsTrue(s.IsValue);
            Assert.AreEqual(SimpleValueType.TimeSpan, s.Value.ValueType);
        }

        [Theory]
        public void CanCreateShortValueOrString_FromUInt(uint value)
        {
            ShortValueOrString s = value;
            Assert.IsTrue(s.IsValue);
            Assert.AreEqual(SimpleValueType.UInt, s.Value.ValueType);
        }

        [Theory]
        public void CanCreateShortValueOrString_FromULong(ulong value)
        {
            ShortValueOrString s = value;
            Assert.IsTrue(s.IsValue);
            Assert.AreEqual(SimpleValueType.ULong, s.Value.ValueType);
        }

        [Theory]
        public void CanCreateShortValueOrString_FromUShort(ushort value)
        {
            ShortValueOrString s = value;
            Assert.IsTrue(s.IsValue);
            Assert.AreEqual(SimpleValueType.UShort, s.Value.ValueType);
        }

        [Theory]
        public void CanCreateShortValueOrString_FromString(string value)
        {
            ShortValueOrString s = value;
            Assert.IsFalse(s.IsValue);
            Assert.AreSame(value, s.Reference);
        }

        [Test]
        public void CanCreateShortValueOrString_FromNull()
        {
            ShortValueOrString s = null;
            Assert.IsFalse(s.IsValue);
            Assert.IsNull(s.Reference);
        }

        [Theory]
        public void SimpleTypeThrows_OnAccessingReference(int value)
        {
            ShortValueOrString s = value;
            Assert.Throws<InvalidOperationException>(() => { _ = s.Reference; });
        }

        [Theory]
        public void ReferenceTypeThrows_OnAccessingValue(string value)
        {
            ShortValueOrString s = value;
            Assert.Throws<InvalidOperationException>(() => { _ = s.Value; });
        }
    }
}