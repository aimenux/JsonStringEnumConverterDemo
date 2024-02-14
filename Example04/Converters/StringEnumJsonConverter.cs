using System.ComponentModel;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Example04.Converters;

public class StringEnumJsonConverter<T> : JsonConverter<T> where T : struct, Enum
{
    private readonly TypeConverter _typeConverter;

    public StringEnumJsonConverter()
    {
        _typeConverter = TypeDescriptor.GetConverter(typeof(T));
    }

    public override bool CanConvert(Type typeToConvert)
    {
        return typeToConvert == typeof(T);
    }

    public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var enumValue = _typeConverter.ConvertFromInvariantString(reader.GetString());
        if (enumValue is null) return default;
        return (T)enumValue;
    }

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        var stringValue = _typeConverter.ConvertToInvariantString(value);
        writer.WriteStringValue(stringValue);
    }
}