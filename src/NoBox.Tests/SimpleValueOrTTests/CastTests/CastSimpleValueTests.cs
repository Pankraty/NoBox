using NUnit.Framework;
using System;

namespace Pankraty.NoBox.Tests.SimpleValueOrTTests.CastTests
{
    using SimpleValueOrString = SimpleValueOr<String>;

    public class CastSimpleValueTests
    {
        [Test]
        public void CannotCastReferenceToSimpleValue()
        {
            SimpleValueOrString v = "Test";
            Assert.Throws<InvalidCastException>(() => { _ = (SimpleValue) (v); });
        }
    }
}