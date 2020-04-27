using NUnit.Framework;
using System;

namespace Pankraty.NoBox.Tests.ShortValueOrTTests
{
    public class ShortValueOrTEqualityTests
    {
        [Test]
        public void ShortValues_AreComparedByValue()
        {
            ShortValueOr<String> value1 = 100;
            ShortValueOr<String> value2 = 100;

            Assert.True(value1.Equals(value2));
            Assert.True(value1 == value2);
            Assert.False(value1 != value2);
            Assert.True(value1.Equals((object)value2));

            Assert.AreEqual(value1.GetHashCode(), value2.GetHashCode());
        }

        [Test]
        public void Objects_AreComparedByReference()
        {
            var object1 = new TestObject();
            var object2 = new TestObject();

            ShortValueOr<TestObject> value1 = object1;
            ShortValueOr<TestObject> value2 = object1;
            ShortValueOr<TestObject> value3 = object2;
            
            Assert.True(value1.Equals(value2));
            Assert.False(value1.Equals(value3));
            Assert.True(value1 == value2);
            Assert.False(value1 != value2);
            Assert.True(value1.Equals((object)value2));

            Assert.AreEqual(value1.GetHashCode(), value2.GetHashCode());
            Assert.AreNotEqual(value2.GetHashCode(), value3.GetHashCode());
        }

        [Test]
        public void IEquatables_AreComparedByEquals()
        {
            var object1 = new EquatableObject(100);
            var object2 = new EquatableObject(100);
            var object3 = new EquatableObject(200);

            ShortValueOr<EquatableObject> value1 = object1;
            ShortValueOr<EquatableObject> value2 = object2;
            ShortValueOr<EquatableObject> value3 = object3;

            Assert.True(value1.Equals(value2));
            Assert.False(value1.Equals(value3));
            Assert.True(value1 == value2);
            Assert.False(value1 != value2);
            Assert.True(value1.Equals((object)value2));

            Assert.AreEqual(value1.GetHashCode(), value2.GetHashCode());
            Assert.AreNotEqual(value2.GetHashCode(), value3.GetHashCode());
        }

        [Test]
        public void NotEquals_ToOtherType()
        {
            ShortValueOr<EquatableObject> value1 = new EquatableObject(100);
            ShortValueOr<TestObject> value2 = new TestObject();
            Assert.False(value1.Equals(value2));
        }

        private class TestObject
        {
        }

        private class EquatableObject : IEquatable<EquatableObject>
        {
            public int Id { get; }

            public EquatableObject(int id)
            {
                Id = id;
            }

            public bool Equals(EquatableObject other)
            {
                return Id == other?.Id;
            }

            public override int GetHashCode()
            {
                return Id * 100;
            }
        }
    }
}
