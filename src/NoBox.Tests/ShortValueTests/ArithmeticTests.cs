using AutoFixture;
using NUnit.Framework;

namespace Pankraty.NoBox.Tests.ShortValueTests
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

            ShortValue a2 = a1;
            ShortValue b2 = b1;
            ShortValue c2 = c1;
            ShortValue d2 = d1;
            ShortValue e2 = e1;
            ShortValue f2 = f1;
            ShortValue g2 = g1;
            ShortValue h2 = h1;
            ShortValue i2 = i1;
            ShortValue j2 = j1;

            //Just some arbitrary computation
            var expectedResult = (double)(j1 * i1) + h1 / (ulong)g1 + f1 * e1 + d1 / c1 - b1 * a1;
            var actualResult =   (double)(j2 * i2) + h2 / (ulong)g2 + f2 * e2 + d2 / c2 - b2 * a2;

            Assert.AreEqual(expectedResult, (decimal)actualResult);
        }
    }
}
