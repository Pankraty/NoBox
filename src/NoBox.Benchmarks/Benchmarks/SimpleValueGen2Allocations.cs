using BenchmarkDotNet.Attributes;
using NoBox.Benchmarks.Generators;
using Pankraty.NoBox;
using System.Collections.Generic;

namespace NoBox.Benchmarks
{
    public class SimpleValueGen2Allocations : IBenchmark
    {
        public string Description => "In this benchmark we generate many simple values (either boxed to Object " +
                                     "or presented as SimpleValue) but do not let them be collected in Gen0. " +
                                     "Here we expect the most apparent difference between the two.";

        public static int Iterations = 10_000_000;

        private readonly BoxedValuesGenerator _boxedValuesGenerator;
        private readonly SimpleValuesGenerator _simpleValuesGenerator;
        public SimpleValueGen2Allocations()
        {
            _boxedValuesGenerator = new BoxedValuesGenerator();
            _simpleValuesGenerator = new SimpleValuesGenerator();
        }

        [Benchmark(Description = "Object (boxing)", Baseline = true)]
        public void Boxing()
        {
            var l = new List<object>();

            var count = 0;

            for (int i = 0; i < Iterations; i++)
            {
                var v = _boxedValuesGenerator.GetNext();
                l.Add(v);
                if (l.Count > 1_000_000)
                    l.Clear();

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
                l.Add(v);
                if (l.Count > 1_000_000)
                    l.Clear();

                if (v.ValueType == SimpleValueType.Bool && v)
                {
                    count++;
                }
            }
        }
    }
}