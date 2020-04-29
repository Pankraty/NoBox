using BenchmarkDotNet.Attributes;
using Pankraty.NoBox.Benchmarks.Generators;
using System.Collections.Generic;

namespace Pankraty.NoBox.Benchmarks.Benchmarks
{
    public class ShortValueGen2Allocations : IBenchmark
    {
        public string Description => "In this benchmark we generate many simple values (either boxed to Object " +
                                     "or presented as ShortValue) but do not let them be collected in Gen0. " +
                                     "Here we expect the most apparent difference between the two.";

        public static int Iterations = 10_000_000;

        private readonly ShortBoxedValuesGenerator _boxedValuesGenerator;
        private readonly ShortValuesGenerator _shortValuesGenerator;
        public ShortValueGen2Allocations()
        {
            _boxedValuesGenerator = new ShortBoxedValuesGenerator();
            _shortValuesGenerator = new ShortValuesGenerator();
        }

        [Benchmark(Description = "Object (boxing)", Baseline = true)]
        public void Boxing()
        {
            var l1 = new List<object>();
            var l2 = new List<object>();

            var count = 0;

            for (int i = 0; i < Iterations; i++)
            {
                var v = _boxedValuesGenerator.GetNext();
                l1.Add(v);
                if (i % 10 == 0)
                    l2.Add(v);

                if (l1.Count > 1_000_000)
                    l1.Clear();

                if (v is bool b)
                {
                    count++;
                }
            }
        }

        [Benchmark(Description = "ShortValue (no boxing)")]
        public void NoBoxing()
        {
            var l1 = new List<ShortValue>();
            var l2 = new List<ShortValue>();

            var count = 0;
            for (int i = 0; i < Iterations; i++)
            {
                var v = _shortValuesGenerator.GetNext();
                l1.Add(v);
                if (i % 10 == 0)
                    l2.Add(v);

                if (l1.Count > 1_000_000)
                    l1.Clear();

                if (v.ValueType == SimpleValueType.Bool && v)
                {
                    count++;
                }
            }
        }
    }
}