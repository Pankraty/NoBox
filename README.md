# NoBox

[![Build status](https://ci.appveyor.com/api/projects/status/3b5mhdn26d19pec9?svg=true)](https://ci.appveyor.com/project/Pankraty/nobox)

Have you ever been struggling with properties that must be able to accept values of various primitive types, such as `int`, `double`, or `decimal`, and return the same value it was put there before? If so, then you probably had to define the type of such property as `System.Object` which basically meant that all values you pass to that property are [boxed and then unboxed](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/types/boxing-and-unboxing). A single boxing operation costs almost nothing, but such operations tend to pile up, inducing a heavy load to the garbage collector (GC).

The `NoBox` library aims to provide an efficient way to operate with primitive values of different types without a need to cast them to `Object` or `ValueType` (thus boxing them). And even though the library is on its earliest beta (or should I say alpha), the first benchmarks look quite promising.


***
For example, let's have a look at [this benchmark](https://github.com/Pankraty/NoBox/blob/master/src/NoBox.Benchmarks/Benchmarks/Gen2AllocationsBenchmark.cs). It creates a bunch of primitive objects of 14 different types and put them into list - either `List<System.Object>` (with boxing) or `List<NoBox.SimpleValue>`. On every 1 000 000th iteration the list is cleared, and objects are released.

Results are fascinating: we've gained more than 3x performance improvement!

```
|                    Method |     Mean |   Error |   StdDev | Ratio |
|-------------------------- |---------:|--------:|---------:|------:|
|         'Object (boxing)' | 471.5 ms | 9.11 ms | 11.85 ms |  1.00 |
| 'SimpleValue (no boxing)' | 130.7 ms | 2.55 ms |  4.53 ms |  0.28 |
```

In [the other benchmark](https://github.com/Pankraty/NoBox/blob/master/src/NoBox.Benchmarks/Benchmarks/Gen0AllocationsBenchmark.cs) we do not preserve the values between iterations, and they are all consumed by GC in generation 0. This time the effect of boxing/unboxing is negligible, and our custom implementation gives way to built-in types, but the difference is about 20-30%, which we find descent.

```
|                    Method |     Mean |    Error |   StdDev |   Median | Ratio | RatioSD |
|-------------------------- |---------:|---------:|---------:|---------:|------:|--------:|
|         'Object (boxing)' | 75.70 ms | 2.428 ms | 7.044 ms | 80.33 ms |  1.00 |    0.00 |
| 'SimpleValue (no boxing)' | 90.12 ms | 1.594 ms | 1.958 ms | 89.28 ms |  1.23 |    0.11 |
```
