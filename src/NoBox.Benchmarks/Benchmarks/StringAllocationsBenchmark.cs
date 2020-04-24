using BenchmarkDotNet.Attributes;
using Pankraty.NoBox.Benchmarks.Generators;
using System;
using System.Collections.Generic;

namespace Pankraty.NoBox.Benchmarks.Benchmarks
{
    public class SimpleValueOrStringAllocations : IBenchmark
    {
        public string Description => "In this benchmark we try to store simple values and strings as either objects or SimpleValueOr<T> structures. " +
                                     "Here we expect some performance benefit due to fewer garbage collections.";

        public static int Iterations = 10_000_000;

        private readonly BoxedValuesGenerator _boxedValuesGenerator;
        private readonly SimpleValuesGenerator _simpleValuesGenerator;
        public SimpleValueOrStringAllocations()
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
                
                if (v is Guid)
                    v = v.ToString();

                l.Add(v);

                if (l.Count > 1_000_000)
                    l.Clear();

                if (v is bool b)
                {
                    count++;
                }
            }
        }

        [Benchmark(Description = "SimpleValueOr<String> (no boxing)")]
        public void NoBoxing()
        {
            var l = new List<SimpleValueOr<String>>();

            var count = 0;

            for (int i = 0; i < Iterations; i++)
            {
                SimpleValueOr<String> v = _simpleValuesGenerator.GetNext();

                if (v.Value.ValueType == SimpleValueType.Guid)
                    v = v.ToString();

                l.Add(v);
                
                if (l.Count > 1_000_000)
                    l.Clear();

                if (v.IsValue && v.Value.ValueType == SimpleValueType.Bool && v.Value)
                {
                    count++;
                }
            }
        }
    }
}