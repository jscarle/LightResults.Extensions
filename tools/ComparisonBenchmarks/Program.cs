using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using Benchmarks = ComparisonBenchmarks.Benchmarks;

BenchmarkRunner.Run<Benchmarks>(ManualConfig.Create(DefaultConfig.Instance).WithOptions(ConfigOptions.DisableOptimizationsValidator));
