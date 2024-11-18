using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace LightResults.Extensions.Json;

/// <summary>Converts a <see cref="Result{TValue}"/> to JSON.</summary>
/// <remarks>This converter only supports serialization.</remarks>
/// <typeparam name="TValue">The type of value of the result.</typeparam>
/// <seealso cref="JsonConverter{T}"/>
[SuppressMessage("Design", "CA1062: Validate arguments of public methods", Justification = "Arguments are provided by the SDK.")]
public sealed class ResultJsonConverter<TValue> : JsonConverter<Result<TValue>>
{
    private const string TypeDiscriminator = "$type";
    private const string IsSuccess = "IsSuccess";
    private const string Value = "Value";
    private const string Errors = "Errors";
    private const string Message = "Message";
    private const string Metadata = "Metadata";
    private const string MetadataValue = "Value";
    private const string ExceptionMessage = "Message";
    private const string ExceptionStackTrace = "StackTrace";
    private const string ExceptionInnerException = "InnerException";

    /// <summary>Reads and converts JSON to a <see cref="Result"/> object.</summary>
    /// <param name="reader">The JSON reader.</param>
    /// <param name="typeToConvert">The type of the object to convert.</param>
    /// <param name="options">The serialization options to use.</param>
    /// <returns>The deserialized <see cref="Result"/> object.</returns>
    /// <exception cref="NotImplementedException">Thrown when the method is called as it's not implemented.</exception>
    public override Result<TValue> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    /// <summary>Writes a <see cref="Result"/> object to JSON.</summary>
    /// <param name="writer">The JSON writer.</param>
    /// <param name="value">The <see cref="Result"/> object to write.</param>
    /// <param name="options">The serialization options to use.</param>
    public override void Write(Utf8JsonWriter writer, Result<TValue> value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();
        writer.WriteBoolean(IsSuccess, value.IsSuccess);
        if (value.IsSuccess)
            WriteObject(writer, Value, value.Value);
        else
            WriteErrors(writer, value);
        writer.WriteEndObject();
    }

    private static void WriteErrors(Utf8JsonWriter writer, Result<TValue> result)
    {
        writer.WritePropertyName(Errors);
        writer.WriteStartArray();
        foreach (var error in result.Errors)
            WriteError(writer, error);
        writer.WriteEndArray();
    }

    private static void WriteError(Utf8JsonWriter writer, IError error)
    {
        writer.WriteStartObject();
        writer.WriteString(TypeDiscriminator, error.GetType().FullName ?? error.GetType().Name);
        writer.WriteString(Message, error.Message);
        if (error.Metadata.Count > 0)
            WriteMetadata(writer, error);
        writer.WriteEndObject();
    }

    private static void WriteMetadata(Utf8JsonWriter writer, IError error)
    {
        writer.WritePropertyName(Metadata);
        writer.WriteStartObject();

        var keys = error.Metadata.Keys.OrderBy(x => x, StringComparer.InvariantCulture);
        foreach (var key in keys)
            WriteMetadataItem(writer, key, error.Metadata[key]);
        writer.WriteEndObject();
    }

    private static void WriteMetadataItem(Utf8JsonWriter writer, string key, object obj)
    {
        if (obj is Exception ex)
        {
            writer.WritePropertyName(key);
            WriteExceptionValue(writer, ex);
            return;
        }

        writer.WritePropertyName(key);
        writer.WriteStartObject();
        writer.WriteString(TypeDiscriminator, obj.GetType().FullName ?? obj.GetType().Name);
        WriteObject(writer, MetadataValue, obj);
        writer.WriteEndObject();
    }

    private static void WriteObject(Utf8JsonWriter writer, string name, object? obj)
    {
        if (obj is null)
        {
            writer.WriteNull(name);
            return;
        }

        switch (obj)
        {
            case bool value:
                writer.WriteBoolean(name, value);
                break;
            case byte value:
                writer.WriteNumber(name, value);
                break;
            case DateTime value:
                writer.WriteString(name, value);
                break;
            case DateTimeOffset value:
                writer.WriteString(name, value);
                break;
            case DateOnly value:
                writer.WritePropertyName(name);
                writer.WriteStringValue(value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
                break;
            case TimeOnly value:
                writer.WritePropertyName(name);
                writer.WriteStringValue(value.ToString("HH:mm:ss", CultureInfo.InvariantCulture));
                break;
            case TimeSpan value:
                writer.WritePropertyName(name);
                writer.WriteNumberValue(value.Ticks);
                break;
            case double value:
                writer.WriteNumber(name, value);
                break;
            case Guid value:
                writer.WriteString(name, value);
                break;
            case short value:
                writer.WriteNumber(name, value);
                break;
            case int value:
                writer.WriteNumber(name, value);
                break;
            case long value:
                writer.WriteNumber(name, value);
                break;
            case sbyte value:
                writer.WriteNumber(name, value);
                break;
            case float value:
                writer.WriteNumber(name, value);
                break;
            case string value:
                writer.WriteString(name, value);
                break;
            case ushort value:
                writer.WriteNumber(name, value);
                break;
            case uint value:
                writer.WriteNumber(name, value);
                break;
            case ulong value:
                writer.WriteNumber(name, value);
                break;
            default:
                writer.WritePropertyName(name);
                JsonSerializer.Serialize(writer, obj, obj.GetType());
                break;
        }
    }

    private static void WriteExceptionValue(Utf8JsonWriter writer, Exception ex)
    {
        writer.WriteStartObject();
        writer.WriteString(TypeDiscriminator, ex.GetType().FullName ?? ex.GetType().Name);
        writer.WriteString(ExceptionMessage, ex.Message);
        writer.WriteString(ExceptionStackTrace, ex.StackTrace);
        if (ex.InnerException is not null)
        {
            writer.WritePropertyName(ExceptionInnerException);
            WriteExceptionValue(writer, ex.InnerException);
        }
        writer.WriteEndObject();
    }
}
