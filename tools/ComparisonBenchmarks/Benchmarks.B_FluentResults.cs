using BenchmarkDotNet.Attributes;
using FluentResults;

namespace ComparisonBenchmarks;

public partial class Benchmarks
{
    private IEnumerable<FluentResults.Result> _fluentResultsEnumerable = null!;
    private IEnumerable<FluentResults.Result<int>> _fluentResultsTValueEnumerable = null!;
    private IReadOnlyList<FluentResults.Result> _fluentResultsReadOnlyList = null!;
    private IReadOnlyList<FluentResults.Result<int>> _fluentResultsTValueReadOnlyList = null!;

    private void SetupFluentResults()
    {
        var random = new Random(Seed);

        var enumerable = new List<FluentResults.Result>();
        for (var i = 0; i < Iterations; i++)
            enumerable.Add(random.Next(0, 1) == 0 ? FluentResults.Result.Ok() : FluentResults.Result.Fail(i.ToString()));
        _fluentResultsEnumerable = enumerable.AsEnumerable();

        var readOnlyList = new List<FluentResults.Result>();
        for (var i = 0; i < Iterations; i++)
            readOnlyList.Add(random.Next(0, 1) == 0 ? FluentResults.Result.Ok() : FluentResults.Result.Fail(i.ToString()));
        _fluentResultsReadOnlyList = readOnlyList;

        var enumerableT = new List<FluentResults.Result<int>>();
        for (var i = 0; i < Iterations; i++)
            enumerableT.Add(random.Next(0, 1) == 0 ? FluentResults.Result.Ok(i) : FluentResults.Result.Fail<int>(i.ToString()));
        _fluentResultsTValueEnumerable = enumerableT.AsEnumerable();

        var readOnlyListT = new List<FluentResults.Result<int>>();
        for (var i = 0; i < Iterations; i++)
            readOnlyListT.Add(random.Next(0, 1) == 0 ? FluentResults.Result.Ok(i) : FluentResults.Result.Fail<int>(i.ToString()));
        _fluentResultsTValueReadOnlyList = readOnlyListT;
    }

    [Benchmark]
    [BenchmarkCategory("A01: Merging multiple results")]
    public FluentResults.Result B_FluentResults_ResultEnumerable_Merge()
    {
        return _fluentResultsEnumerable.Merge();
    }

    [Benchmark]
    [BenchmarkCategory("A01: Merging multiple results")]
    public FluentResults.Result B_FluentResults_ResultReadOnlyList_Merge()
    {
        return _fluentResultsReadOnlyList.Merge();
    }

    [Benchmark]
    [BenchmarkCategory("A02: Merging multiple results with values")]
    public FluentResults.Result<IEnumerable<int>> B_FluentResults_ResultTValue_Merge()
    {
        return _fluentResultsTValueEnumerable.Merge();
    }

    [Benchmark]
    [BenchmarkCategory("A02: Merging multiple results with values")]
    public FluentResults.Result<IEnumerable<int>> B_FluentResults_ResultTValueReadOnlyList_Merge()
    {
        return _fluentResultsTValueReadOnlyList.Merge();
    }
}
