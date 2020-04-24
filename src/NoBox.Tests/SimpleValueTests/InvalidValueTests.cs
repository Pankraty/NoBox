using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pankraty.NoBox.Tests.SimpleValueTests
{
    public class InvalidValueTests
    {
        private SimpleValue InvalidValue = default;

        [Test]
        public void ValueTypeNotSet()
        {
            Assert.AreEqual(SimpleValueType.NotSet, InvalidValue.ValueType);
        }

        [Test]
        public void ToStringThrows()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => InvalidValue.ToString());
        }

        [TestCaseSource(nameof(InvalidCastSources))]
        public void CannotCastInvalidToAny<T>(Func<SimpleValue, T> castMethod)
        {
            Assert.Throws<InvalidCastException>(() => castMethod(InvalidValue));
        }

        private static IEnumerable<TestCaseData> InvalidCastSources
        {
            get
            {
                yield return new TestCaseData(new Func<SimpleValue, bool          >(v => v));
                yield return new TestCaseData(new Func<SimpleValue, sbyte         >(v => v));
                yield return new TestCaseData(new Func<SimpleValue, byte          >(v => v));
                yield return new TestCaseData(new Func<SimpleValue, short         >(v => v));
                yield return new TestCaseData(new Func<SimpleValue, ushort        >(v => v));
                yield return new TestCaseData(new Func<SimpleValue, int           >(v => v));
                yield return new TestCaseData(new Func<SimpleValue, uint          >(v => v));
                yield return new TestCaseData(new Func<SimpleValue, long          >(v => v));
                yield return new TestCaseData(new Func<SimpleValue, ulong         >(v => v));
                yield return new TestCaseData(new Func<SimpleValue, float         >(v => v));
                yield return new TestCaseData(new Func<SimpleValue, double        >(v => v));
                yield return new TestCaseData(new Func<SimpleValue, char          >(v => v));
                yield return new TestCaseData(new Func<SimpleValue, DateTime      >(v => v));
                yield return new TestCaseData(new Func<SimpleValue, DateTimeOffset>(v => v));
                yield return new TestCaseData(new Func<SimpleValue, TimeSpan      >(v => v));
                yield return new TestCaseData(new Func<SimpleValue, Guid          >(v => v));
                yield return new TestCaseData(new Func<SimpleValue, decimal       >(v => v));
            }
        }
    }
}
