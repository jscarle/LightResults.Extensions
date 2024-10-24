using Microsoft.CodeAnalysis;

namespace LightResults.Extensions.GeneratedIdentifier.Common;

internal static class IncrementalValueProviderExtensions
{
    public static IncrementalValuesProvider<TSource> WhereNotNull<TSource>(this IncrementalValuesProvider<TSource?> source)
        where TSource : struct
    {
        return source.Where(x => x is not null)
            .Select((x, _) => x!.Value);
    }
}
