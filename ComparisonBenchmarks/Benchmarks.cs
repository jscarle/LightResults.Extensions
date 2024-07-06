using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using JetBrains.Annotations;

namespace ComparisonBenchmarks;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net80)]
[IterationTime(250)]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[CategoriesColumn]
[HideColumns(Column.Job, Column.Error, Column.StdDev, Column.Median, Column.RatioSD, Column.Gen0, Column.Gen1, Column.Gen2)]
public partial class Benchmarks
{
    [UsedImplicitly]
    [Params(10, 100, 1000, 10000)]
    public int Iterations { get; set; }

    private const int Seed = 42;

    [GlobalSetup]
    public void GlobalSetup()
    {
        SetupLightResults();
        SetupFluentResults();
        SetupRascal();
    }
}
