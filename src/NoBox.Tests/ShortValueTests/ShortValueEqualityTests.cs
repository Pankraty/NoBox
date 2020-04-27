using NUnit.Framework;

namespace Pankraty.NoBox.Tests.ShortValueTests
{
    public class ShortValueEqualityTests
    {
        [Test]
        public void ShortValues_AreComparedByTypeAndValue()
        {
            ShortValue value1 = (byte)100;
            ShortValue value2 = (byte)100;
            ShortValue value3 = (long)100;

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