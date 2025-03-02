using BenchmarkDotNet.Attributes;
using Rascal;

namespace ComparisonBenchmarks;

public partial class Benchmarks
{
    private IEnumerable<Rascal.Result<int>> _rascalResultsTValueEnumerable = null!;
    private IReadOnlyList<Rascal.Result<int>> _rascalResultsTValueReadOnlyList = null!;

    private void SetupRascal()
    {
        var random = new Random(Seed);

        var enumerableT = new List<Rascal.Result<int>>();
        for (var i = 0; i < Iterations; i++)
            enumerableT.Add(random.Next(0, 1) == 0 ? Prelude.Ok(i) : Prelude.Err<int>(i.ToString()));
        _rascalResultsTValueEnumerable = enumerableT.AsEnumerable();

        var readOnlyListT = new List<Rascal.Result<int>>();
        for (var i = 0; i < Iterations; i++)
            readOnlyListT.Add(random.Next(0, 1) == 0 ? Prelude.Ok(i) : Prelude.Err<int>(i.ToString()));
        _rascalResultsTValueReadOnlyList = readOnlyListT;
    }

    [Benchmark]
    [BenchmarkCategory("A02: Merging multiple results with values")]
    public Rascal.Result<IReadOnlyList<int>> E_Rascal_ResultEnumerable_Sequence()
    {
        return _rascalResultsTValueEnumerable.Sequence();
    }

    [Benchmark]
    [BenchmarkCategory("A02: Merging multiple results with values")]
    public Rascal.Result<IReadOnlyList<int>> E_Rascal_ResultReadOnlyList_Sequence()
    {
        return _rascalResultsTValueReadOnlyList.Sequence();
    }
}
