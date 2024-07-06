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
[HideColumns(Column.Job, Column.Error, Column.StdDev, Column.Median, Column.RatioSD, Column.Gen0, Column.Gen1, Column.Gen2)]
public class Benchmarks
{
    private const int Seed = 42;
    private IEnumerable<Result> _enumerableAllOk = null!;
    private IEnumerable<Result<string>> _enumerableTAllOk = null!;
    private IEnumerable<Result> _enumerableAllFailed = null!;
    private IEnumerable<Result<string>> _enumerableTAllFailed = null!;
    private IEnumerable<Result> _enumerableMixed = null!;
    private IEnumerable<Result<string>> _enumerableTMixed = null!;
    private IReadOnlyList<Result> _readOnlyListAllOk = null!;
    private IReadOnlyList<Result<string>> _readOnlyListTAllOk = null!;
    private IReadOnlyList<Result> _readOnlyListAllFailed = null!;
    private IReadOnlyList<Result<string>> _readOnlyListTAllFailed = null!;
    private IReadOnlyList<Result> _readOnlyListMixed = null!;
    private IReadOnlyList<Result<string>> _readOnlyListTMixed = null!;

    [UsedImplicitly]
    [Params(10, 100, 1000, 10000)]
    public int Iterations { get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
        _enumerableAllOk = GetEnumerableResults(ResultType.AllOk);
        _enumerableTAllOk = GetEnumerableTResults(ResultType.AllOk);
        _enumerableAllFailed = GetEnumerableResults(ResultType.AllFailed);
        _enumerableTAllFailed = GetEnumerableTResults(ResultType.AllFailed);
        _enumerableMixed = GetEnumerableResults(ResultType.Mixed);
        _enumerableTMixed = GetEnumerableTResults(ResultType.Mixed);
        _readOnlyListAllOk = GetReadOnlyListResults(ResultType.AllOk);
        _readOnlyListTAllOk = GetReadOnlyListTResults(ResultType.AllOk);
        _readOnlyListAllFailed = GetReadOnlyListResults(ResultType.AllFailed);
        _readOnlyListTAllFailed = GetReadOnlyListTResults(ResultType.AllFailed);
        _readOnlyListMixed = GetReadOnlyListResults(ResultType.Mixed);
        _readOnlyListTMixed = GetReadOnlyListTResults(ResultType.Mixed);
    }

    private IEnumerable<Result> GetEnumerableResults(ResultType resultType)
    {
        var (min, max) = GetMinMax(resultType);
        var random = new Random(Seed);
        var enumerableAllOk = new List<Result>();
        for (var index = 0; index < Iterations; index++)
            enumerableAllOk.Add(random.Next(min, max) == 0 ? Result.Ok() : Result.Fail(index.ToString()));
        return enumerableAllOk.AsEnumerable();
    }

    private IEnumerable<Result<string>> GetEnumerableTResults(ResultType resultType)
    {
        var (min, max) = GetMinMax(resultType);
        var random = new Random(Seed);
        var enumerableTAllOk = new List<Result<string>>();
        for (var index = 0; index < Iterations; index++)
            enumerableTAllOk.Add(random.Next(min, max) == 0 ? Result.Ok(index.ToString()) : Result.Fail<string>(index.ToString()));
        return enumerableTAllOk.AsEnumerable();
    }

    private IReadOnlyList<Result> GetReadOnlyListResults(ResultType resultType)
    {
        var (min, max) = GetMinMax(resultType);
        var random = new Random(Seed);
        var readOnlyListAllOk = new List<Result>();
        for (var index = 0; index < Iterations; index++)
            readOnlyListAllOk.Add(random.Next(min, max) == 0 ? Result.Ok() : Result.Fail(index.ToString()));
        return readOnlyListAllOk.AsReadOnly();
    }

    private IReadOnlyList<Result<string>> GetReadOnlyListTResults(ResultType resultType)
    {
        var (min, max) = GetMinMax(resultType);
        var random = new Random(Seed);
        var readOnlyListTAllOk = new List<Result<string>>();
        for (var index = 0; index < Iterations; index++)
            readOnlyListTAllOk.Add(random.Next(min, max) == 0 ? Result.Ok(index.ToString()) : Result.Fail<string>(index.ToString()));
        return readOnlyListTAllOk.AsReadOnly();
    }

    private static (int Min, int Max) GetMinMax(ResultType resultType)
    {
        int min;
        int max;
        switch (resultType)
        {
            case ResultType.AllOk:
                min = 0;
                max = 0;
                break;
            case ResultType.AllFailed:
                min = 1;
                max = 1;
                break;
            case ResultType.Mixed:
                min = 0;
                max = 1;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(resultType), resultType, null);
        }
        return (min, max);
    }

    private enum ResultType
    {
        AllOk = 0,
        AllFailed = 1,
        Mixed = 2,
    }

    [Benchmark]
    public Result Result_Collect_WithEnumerable_AllOk()
    {
        return _enumerableAllOk.Collect();
    }
    
    [Benchmark]
    public Result<IReadOnlyList<string>> ResultT_Collect_WithEnumerable_AllOk()
    {
        return _enumerableTAllOk.Collect();
    }
    
    [Benchmark]
    public Result Result_Collect_WithEnumerable_AllFailed()
    {
        return _enumerableAllFailed.Collect();
    }
    
    [Benchmark]
    public Result<IReadOnlyList<string>> ResultT_Collect_WithEnumerable_AllFailed()
    {
        return _enumerableTAllFailed.Collect();
    }
    
    [Benchmark]
    public Result Result_Collect_WithEnumerable_Mixed()
    {
        return _enumerableMixed.Collect();
    }
    
    [Benchmark]
    public Result<IReadOnlyList<string>> ResultT_Collect_WithEnumerable_Mixed()
    {
        return _enumerableTMixed.Collect();
    }
    
    [Benchmark]
    public Result Result_Collect_WithReadOnlyList_AllOk()
    {
        return _readOnlyListAllOk.Collect();
    }
    
    [Benchmark]
    public Result<IReadOnlyList<string>> ResultT_Collect_WithReadOnlyList_AllOk()
    {
        return _readOnlyListTAllOk.Collect();
    }
    
    [Benchmark]
    public Result Result_Collect_WithReadOnlyList_AllFailed()
    {
        return _readOnlyListAllFailed.Collect();
    }
    
    [Benchmark]
    public Result<IReadOnlyList<string>> ResultT_Collect_WithReadOnlyList_AllFailed()
    {
        return _readOnlyListTAllFailed.Collect();
    }
    
    [Benchmark]
    public Result Result_Collect_WithReadOnlyList_Mixed()
    {
        return _readOnlyListMixed.Collect();
    }
    
    [Benchmark]
    public Result<IReadOnlyList<string>> ResultT_Collect_WithReadOnlyList_Mixed()
    {
        return _readOnlyListTMixed.Collect();
    }
}
