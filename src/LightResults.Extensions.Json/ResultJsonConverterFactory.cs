using System.Text.Json;
using System.Text.Json.Serialization;

namespace LightResults.Extensions.Json;

/// <summary>JsonConverterFactory for converting Result types to and from JSON.</summary>
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
