using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;

namespace NoBox.Benchmarks
{
    class Program
    {
        private static readonly Dictionary<char, Type> _benchmarks = 
            new Dictionary<char, Type> {
                {'1', typeof(Gen0AllocationsBenchmark) },
                {'2', typeof(Gen2AllocationsBenchmark) },
            };

        static void Main(string[] args)
        {
            ConsoleKeyInfo key;
            Type benchmarkType = null;
            do
            {
                Console.WriteLine("Choose a benchmark to run or press Enter to exit");

                foreach (var pair in _benchmarks)
                {
                    Console.WriteLine($"  {pair.Key} - {pair.Value.Name}");
                }

                key = Console.ReadKey();

            } while (key.Key != ConsoleKey.Enter && !_benchmarks.TryGetValue(key.KeyChar, out benchmarkType));
            
            if (benchmarkType == null)
                return;

            RunBenchmark(benchmarkType);
        }

        private static void RunBenchmark(Type benchmarkType)
        {
            BenchmarkRunner.Run(benchmarkType, null);

            var benchmarkInstance = Activator.CreateInstance(benchmarkType);
            if (benchmarkInstance is IBenchmark benchmarkInfo)
                Console.WriteLine(benchmarkInfo.Description);

            Console.WriteLine("Execution is finished");
        }
    }
}
    
