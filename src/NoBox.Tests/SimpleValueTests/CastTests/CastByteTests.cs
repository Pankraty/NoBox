using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Pankraty.NoBox.Tests.SimpleValueTests.CastTests
{
    public class CastByteTests : SimpleValueCastTestBase
    {
        private const byte Default = byte.MaxValue;

        [TestCaseSource(nameof(CastByteValidSources))]
        public T CanCastByteToNumbers<T>(Func<SimpleValue, T> castMethod, byte initialValue)
        {
            SimpleValue v = initialValue;

            return castMethod(v);
        }

        private static IEnumerable<TestCaseData> CastByteValidSources
        {
            get
            {
                yield return new TestCaseData(new Func<SimpleValue, sbyte   >(v => v), (byte)1).Returns((sbyte  )1);
                yield return new TestCaseData(new Func<SimpleValue, sbyte   >(v => v), Default).Returns((sbyte  )-1);
                yield return new TestCaseData(new Func<SimpleValue, byte    >(v => v), Default).Returns((byte   )Default);
                yield return new TestCaseData(new Func<SimpleValue, short   >(v => v), Default).Returns((short  )Default);
                yield return new TestCaseData(new Func<SimpleValue, ushort  >(v => v), Default).Returns((ushort )Default);
                yield return new TestCaseData(new Func<SimpleValue, int     >(v => v), Default).Returns((int    )Default);
                yield return new TestCaseData(new Func<SimpleValue, uint    >(v => v), Default).Returns((uint   )Default);
                yield return new TestCaseData(new Func<SimpleValue, long    >(v => v), Default).Returns((long   )Default);
                yield return new TestCaseData(new Func<SimpleValue, ulong   >(v => v), Default).Returns((ulong  )Default);
                yield return new TestCaseData(new Func<SimpleValue, float   >(v => v), Default).Returns((float  )Default);
                yield return new TestCaseData(new Func<SimpleValue, double  >(v => v), Default).Returns((double )Default);
                yield return new TestCaseData(new Func<SimpleValue, char    >(v => v), Default).Returns((char   )Default);
                yield return new TestCaseData(new Func<SimpleValue, decimal >(v => v), Default).Returns((decimal)Default);
            }
        }

        [TestCaseSource(nameof(CastNumberInvalidSources))]
        public void CannotCastByteToNonNumbers<T>(Func<SimpleValue, T> castMethod)
        {
            SimpleValue v = Default;

            Assert.Throws<InvalidCastException>(() => castMethod(v));
        }
    }
}