using BenchmarkDotNet.Attributes;
using LightResults;
using LightResults.Extensions.Operations;

namespace ComparisonBenchmarks;

public partial class Benchmarks
{
    private IEnumerable<Result> _lightResultsEnumerable = null!;
    private IEnumerable<Result<int>> _lightResultsTValueEnumerable = null!;
    private IReadOnlyList<Result> _lightResultsReadOnlyList = null!;
    private IReadOnlyList<Result<int>> _lightResultsTValueReadOnlyList = null!;

    private void SetupLightResults()
    {
        var random = new Random(Seed);

        var enumerable = new List<Result>();
        for (int i = 0; i < Iterations; i++)
            enumerable.Add(random.Next(0, 1) == 0 ? Result.Success() : Result.Failure(i.ToString()));
        _lightResultsEnumerable = enumerable.AsEnumerable();

        var readOnlyList = new List<Result>();
        for (int i = 0; i < Iterations; i++)
            readOnlyList.Add(random.Next(0, 1) == 0 ? Result.Success() : Result.Failure(i.ToString()));
        _lightResultsReadOnlyList = readOnlyList;

        var enumerableT = new List<Result<int>>();
        for (int i = 0; i < Iterations; i++)
            enumerableT.Add(random.Next(0, 1) == 0 ? Result.Success(i) : Result.Failure<int>(i.ToString()));
        _lightResultsTValueEnumerable = enumerableT.AsEnumerable();

        var readOnlyListT = new List<Result<int>>();
        for (int i = 0; i < Iterations; i++)
            readOnlyListT.Add(random.Next(0, 1) == 0 ? Result.Success(i) : Result.Failure<int>(i.ToString()));
        _lightResultsTValueReadOnlyList = readOnlyListT;
    }

    [Benchmark(Baseline = true)]
    [BenchmarkCategory("A01: Merging multiple results")]
    public Result A_LightResults_ResultEnumerable_Collect()
    {
        return _lightResultsEnumerable.Collect();
    }

    [Benchmark]
    [BenchmarkCategory("A01: Merging multiple results")]
    public Result A_LightResults_ResultReadOnlyList_Collect()
    {
        return _lightResultsReadOnlyList.Collect();
    }

    [Benchmark(Baseline = true)]
    [BenchmarkCategory("A02: Merging multiple results with values")]
    public Result<IReadOnlyList<int>> A_LightResults_ResultTValueEnumerable_Collect()
    {
        return _lightResultsTValueEnumerable.Collect();
    }

    [Benchmark]
    [BenchmarkCategory("A02: Merging multiple results with values")]
    public Result<IReadOnlyList<int>> A_LightResults_ResultTValueReadOnlyList_Collect()
    {
        return _lightResultsTValueReadOnlyList.Collect();
    }
}
