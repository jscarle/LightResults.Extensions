using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Jobs;
using JetBrains.Annotations;
using LightResults;
using LightResults.Extensions.Operations;

namespace Benchmarks;

// ReSharper disable RedundantTypeArgumentsOfMethod
[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net90)]
[IterationTime(250)]
[HideColumns(Column.Job, Column.Iterations, Column.Error, Column.StdDev, Column.Median, Column.RatioSD, Column.Gen0, Column.Gen1, Column.Gen2)]
public class Benchmarks
{
    private const int Seed = 42;
    private IEnumerable<Result> _enumerable = null!;
    private IEnumerable<Result<string>> _enumerableT = null!;
    private IReadOnlyList<Result> _readOnlyList = null!;
    private IReadOnlyList<Result<string>> _readOnlyListT = null!;

    [UsedImplicitly]
    [Params(10, 100, 1000, 10000)]
    public int Iterations { get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
        var random = new Random(Seed);

        var enumerable = new List<Result>();
        for (var index = 0; index < Iterations; index++)
            enumerable.Add(random.Next(0, 1) == 0 ? Result.Ok() : Result.Fail(index.ToString()));
        _enumerable = enumerable.AsEnumerable();

        var readOnlyList = new List<Result>();
        for (var index = 0; index < Iterations; index++)
            readOnlyList.Add(random.Next(0, 1) == 0 ? Result.Ok() : Result.Fail(index.ToString()));
        _readOnlyList = readOnlyList;

        var enumerableT = new List<Result<string>>();
        for (var index = 0; index < Iterations; index++)
            enumerableT.Add(random.Next(0, 1) == 0 ? Result.Ok(index.ToString()) : Result.Fail<string>(index.ToString()));
        _enumerableT = enumerableT.AsEnumerable();

        var readOnlyListT = new List<Result<string>>();
        for (var index = 0; index < Iterations; index++)
            readOnlyListT.Add(random.Next(0, 1) == 0 ? Result.Ok(index.ToString()) : Result.Fail<string>(index.ToString()));
        _readOnlyListT = readOnlyListT;
    }

    [Benchmark]
    public Result Result_Collect_WithEnumerable()
    {
        return _enumerable.Collect();
    }

    [Benchmark]
    public Result Result_Collect_WithReadOnlyList()
    {
        return _readOnlyList.Collect();
    }

    [Benchmark]
    public Result<IReadOnlyList<string>> ResultT_Collect_WithEnumerable()
    {
        return _enumerableT.Collect();
    }

    [Benchmark]
    public Result<IReadOnlyList<string>> ResultT_Collect_WithReadOnlyList()
    {
        return _readOnlyListT.Collect();
    }
}
