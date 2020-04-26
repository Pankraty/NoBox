using NUnit.Framework;
using System;
using System.Runtime.CompilerServices;

namespace Pankraty.NoBox.Tests.Common
{
    public class CastDefinition<TIn, TOut> : CastDefinition
    {
        public TIn InputValue { get; }

        public CastTo<TIn, TOut> Cast { get; }

        public TOut ExpectedResult { get; }

        public Type ExpectedException { get; }

        public override string InputDescription => InputValue.ToString();

        private CastDefinition(TIn inputValue, CastTo<TIn, TOut> castMethod, int id)
        {
            From = typeof(TIn);
            To = typeof(TOut);
            Id = id;
            InputValue = inputValue;
            Cast = castMethod;
        }

        public CastDefinition(TIn inputValue, CastTo<TIn, TOut> castMethod, TOut expectedResult, [CallerLineNumber]int id = 0) : this(inputValue, castMethod, id)
        {
            ExpectedResult = expectedResult;
            IsValid = true;
        }

        public CastDefinition(TIn inputValue, CastTo<TIn, TOut> castMethod, Type expectedException, [CallerLineNumber]int id = 0) : this(inputValue, castMethod, id)
        {
            ExpectedException = expectedException;
            IsValid = false;
        }

        public override void PerformCast()
        {
            if (IsValid)
            {
                var actualResult = Cast(InputValue);
                Assert.AreEqual(ExpectedResult, actualResult);
            }
            else
            {
                Assert.Throws(ExpectedException, () => { _ = Cast(InputValue); });
            }
        }
    }

    public abstract class CastDefinition
    {
        public int Id { get; protected set; }
        public Type From { get; protected set; }
        public Type To { get; protected set; }
        public bool IsValid { get; protected set; }

        public abstract string InputDescription { get; }

        public abstract void PerformCast();

        public TestCaseData ToTestCase()
        {
            var isValidText = IsValid ? "VALID" : "INVALID";
            return new TestCaseData(new Action(PerformCast)).SetName(
                $"#{Id.ToString().PadLeft(4)} {isValidText}: {InputDescription} as {From.Name} => {To.Name}");
        }
    }

    public delegate TOut CastTo<in TIn, out TOut>(TIn value);
}