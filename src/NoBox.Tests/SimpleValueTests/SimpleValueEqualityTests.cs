using NUnit.Framework;

namespace Pankraty.NoBox.Tests.SimpleValueTests
{
    public class SimpleValueEqualityTests
    {
        [Test]
        public void SimpleValues_AreComparedByTypeAndValue()
        {
            SimpleValue value1 = (byte)100;
            SimpleValue value2 = (byte)100;
            SimpleValue value3 = (long)100;

            Assert.True(value1 == value2);
            Assert.False(value1 != value2);
            Assert.True(value1.Equals(value2));
            Assert.True(value1.Equals((object)value2));

            Assert.False(value1 == value3);
            Assert.True(value1 != value3);
            Assert.False(value1.Equals(value3));
            Assert.False(value1.Equals((object)value3));
        }
    }
}