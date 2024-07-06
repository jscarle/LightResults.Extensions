using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace LightResults.Extensions.Json;

/// <summary>JsonConverterFactory for converting Result types to and from JSON.</summary>
#if NET7_0_OR_GREATER
[RequiresDynamicCode("The native code for this instantiation might not be available at runtime.")]
[RequiresUnreferencedCode("If some of the generic arguments are annotated (either with DynamicallyAccessedMembersAttribute, or generic constraints), trimming can\'t validate that the requirements of those annotations are met.")]
#endif
public class ResultJsonConverterFactory : JsonConverterFactory
{
    /// <inheritdoc/>
    public override bool CanConvert(Type? typeToConvert)
    {
        if (typeToConvert is null)
            return false;

        return (typeToConvert.IsGenericType && typeToConvert.GetGenericTypeDefinition() == typeof(Result<>)) || typeToConvert == typeof(Result);
    }

    /// <inheritdoc/>
    public override JsonConverter? CreateConverter(Type? typeToConvert, JsonSerializerOptions options)
    {
        if (typeToConvert is null)
            return null;

        if (typeToConvert.IsGenericType && typeToConvert.GetGenericTypeDefinition() == typeof(Result<>))
        {
            var valueType = typeToConvert.GetGenericArguments()[0];
            var converterType = typeof(ResultJsonConverter<>).MakeGenericType(valueType);
            return (JsonConverter?)Activator.CreateInstance(converterType);
        }
        else
        {
            var converterType = typeof(ResultJsonConverter);
            return (JsonConverter?)Activator.CreateInstance(converterType);
        }
    }
}
