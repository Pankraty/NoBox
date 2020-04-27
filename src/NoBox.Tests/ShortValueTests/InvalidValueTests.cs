using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Pankraty.NoBox.Tests.ShortValueTests
{
    public class InvalidValueTests
    {
        private ShortValue InvalidValue = default;

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
        public void CannotCastInvalidToAny<T>(Func<ShortValue, T> castMethod)
        {
            Assert.Throws<InvalidCastException>(() => castMethod(InvalidValue));
        }

        private static IEnumerable<TestCaseData> InvalidCastSources
        {
            get
            {
                yield return new TestCaseData(new Func<ShortValue, bool          >(v => v));
                yield return new TestCaseData(new Func<ShortValue, sbyte         >(v => v));
                yield return new TestCaseData(new Func<ShortValue, byte          >(v => v));
                yield return new TestCaseData(new Func<ShortValue, short         >(v => v));
                yield return new TestCaseData(new Func<ShortValue, ushort        >(v => v));
                yield return new TestCaseData(new Func<ShortValue, int           >(v => v));
                yield return new TestCaseData(new Func<ShortValue, uint          >(v => v));
                yield return new TestCaseData(new Func<ShortValue, long          >(v => v));
                yield return new TestCaseData(new Func<ShortValue, ulong         >(v => v));
                yield return new TestCaseData(new Func<ShortValue, float         >(v => v));
                yield return new TestCaseData(new Func<ShortValue, double        >(v => v));
                yield return new TestCaseData(new Func<ShortValue, char          >(v => v));
                yield return new TestCaseData(new Func<ShortValue, DateTime      >(v => v));
                yield return new TestCaseData(new Func<ShortValue, TimeSpan      >(v => v));
            }
        }
    }
}
