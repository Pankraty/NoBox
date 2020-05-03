using BenchmarkDotNet.Attributes;
using Pankraty.NoBox.Benchmarks.Generators;
using System.Collections.Generic;

namespace Pankraty.NoBox.Benchmarks.Benchmarks
{
    [MemoryDiagnoser]
    public class SimpleValueGen0Allocations : IBenchmark
    {
        public string Description => "In this benchmark we generate many simple values (either boxed to Object " +
                                     "or presented as SimpleValue) that are mostly collected in Gen0. It is natural " +
                                     "that native types work faster, we just make sure our implementation is not too bad " +
                                     "in this scenario";

        public static int Iterations = 10_000_000;

        private readonly BoxedValuesGenerator _boxedValuesGenerator;
        private readonly SimpleValuesGenerator _simpleValuesGenerator;
        public SimpleValueGen0Allocations()
        {
            _boxedValuesGenerator = new BoxedValuesGenerator();
            _simpleValuesGenerator = new SimpleValuesGenerator();
        }

        [Benchmark(Description = "Object (boxing)", Baseline = true)]
        public void Boxing()
        {
            var count = 0;

            for (int i = 0; i < Iterations; i++)
            {
                var v = _boxedValuesGenerator.GetNext();
                
                if (v is bool b)
                {
                    count++;
                }
            }
        }

        [Benchmark(Description = "SimpleValue (no boxing)")]
        public void NoBoxing()
        {
            var l = new List<SimpleValue>();

            var count = 0;
            for (int i = 0; i < Iterations; i++)
            {
                var v = _simpleValuesGenerator.GetNext();

                if (v.ValueType == SimpleValueType.Bool && v)
                {
                    count++;
                }
            }
        }
    }
}