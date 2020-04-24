using AutoFixture;
using NUnit.Framework;

namespace Pankraty.NoBox.Tests.SimpleValueTests
{
    public class ArithmeticTests
    {
        private readonly Fixture _fixture;

        public ArithmeticTests()
        {
            _fixture = new Fixture();
        }

        [Test]
        public void CheckArithmetic()
        {
            var a1 = _fixture.Create<sbyte  >();
            var b1 = _fixture.Create<byte   >();
            var c1 = _fixture.Create<short  >();
            var d1 = _fixture.Create<ushort >();
            var e1 = _fixture.Create<int    >();
            var f1 = _fixture.Create<uint   >();
            var g1 = _fixture.Create<long   >();
            var h1 = _fixture.Create<ulong  >();
            var i1 = _fixture.Create<float  >();
            var j1 = _fixture.Create<double >();
            var k1 = _fixture.Create<decimal>();

            SimpleValue a2 = a1;
            SimpleValue b2 = b1;
            SimpleValue c2 = c1;
            SimpleValue d2 = d1;
            SimpleValue e2 = e1;
            SimpleValue f2 = f1;
            SimpleValue g2 = g1;
            SimpleValue h2 = h1;
            SimpleValue i2 = i1;
            SimpleValue j2 = j1;
            SimpleValue k2 = k1;

            //Just some arbitrary computation
            var expectedResult = k1 - (decimal)(j1 * i1) + h1 / (ulong)g1 + f1 * e1 + d1 / c1 - b1 * a1;
            var actualResult =   k2 - (decimal)(j2 * i2) + h2 / (ulong)g2 + f2 * e2 + d2 / c2 - b2 * a2;

            Assert.AreEqual(expectedResult, (decimal)actualResult);
        }


    }
}
