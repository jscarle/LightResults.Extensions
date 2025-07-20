using BenchmarkDotNet.Attributes;
using FluentResults;

namespace ComparisonBenchmarks;

public partial class Benchmarks
{
    private IEnumerable<Result> _fluentResultsEnumerable = null!;
    private IEnumerable<Result<int>> _fluentResultsTValueEnumerable = null!;
    private IReadOnlyList<Result> _fluentResultsReadOnlyList = null!;
    private IReadOnlyList<Result<int>> _fluentResultsTValueReadOnlyList = null!;

    private void SetupFluentResults()
    {
        var random = new Random(Seed);

        var enumerable = new List<Result>();
        for (var i = 0; i < Iterations; i++)
            enumerable.Add(random.Next(0, 1) == 0 ? Result.Ok() : Result.Fail(i.ToString()));
        _fluentResultsEnumerable = enumerable.AsEnumerable();

        var readOnlyList = new List<Result>();
        for (var i = 0; i < Iterations; i++)
            readOnlyList.Add(random.Next(0, 1) == 0 ? Result.Ok() : Result.Fail(i.ToString()));
        _fluentResultsReadOnlyList = readOnlyList;

        var enumerableT = new List<Result<int>>();
        for (var i = 0; i < Iterations; i++)
            enumerableT.Add(random.Next(0, 1) == 0 ? Result.Ok(i) : Result.Fail<int>(i.ToString()));
        _fluentResultsTValueEnumerable = enumerableT.AsEnumerable();

        var readOnlyListT = new List<Result<int>>();
        for (var i = 0; i < Iterations; i++)
            readOnlyListT.Add(random.Next(0, 1) == 0 ? Result.Ok(i) : Result.Fail<int>(i.ToString()));
        _fluentResultsTValueReadOnlyList = readOnlyListT;
    }

    [Benchmark]
    [BenchmarkCategory("A01: Merging multiple results")]
    public Result B_FluentResults_ResultEnumerable_Merge()
    {
        return _fluentResultsEnumerable.Merge();
    }

    [Benchmark]
    [BenchmarkCategory("A01: Merging multiple results")]
    public Result B_FluentResults_ResultReadOnlyList_Merge()
    {
        return _fluentResultsReadOnlyList.Merge();
    }

    [Benchmark]
    [BenchmarkCategory("A02: Merging multiple results with values")]
    public Result<IEnumerable<int>> B_FluentResults_ResultTValue_Merge()
    {
        return _fluentResultsTValueEnumerable.Merge();
    }

    [Benchmark]
    [BenchmarkCategory("A02: Merging multiple results with values")]
    public Result<IEnumerable<int>> B_FluentResults_ResultTValueReadOnlyList_Merge()
    {
        return _fluentResultsTValueReadOnlyList.Merge();
    }
}
