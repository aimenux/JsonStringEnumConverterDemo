using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Example03.Converters;

public class JsonStringEnumConverter<T> : JsonConverter<T> where T : struct, Enum
{
    static JsonStringEnumConverter()
    {
        Cache.Add(typeof(T), CreateEnumDictionary<T>());
    }

    private static readonly Dictionary<Type, Dictionary<string, T>> Cache = new Dictionary<Type, Dictionary<string, T>>();

    public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var stringValue = reader.GetString() ?? "";

        if (Cache[typeof(T)].TryGetValue(stringValue, out var enumValue))
        {
            return enumValue;
        }

        if (int.TryParse(stringValue, out var integerValue))
        {
            return (T)Enum.ToObject(typeof(T), integerValue);
        }

        return default;
    }

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        var stringValue = Cache[typeof(T)].FirstOrDefault(x => x.Value.Equals(value)).Key;

        if (int.TryParse(stringValue, out var integerValue))
        {
            writer.WriteNumberValue(integerValue);
        }
        else
        {
            writer.WriteStringValue(stringValue ?? value.ToString());
        }
    }

    private static Dictionary<string, T> CreateEnumDictionary<TEnumType>()
    {
        return Enum.GetValues(typeof(TEnumType)).Cast<T>().ToDictionary(e => ToEnumMember(e) ?? e.ToString(), e => e, StringComparer.OrdinalIgnoreCase);
    }

    private static string ToEnumMember(Enum enumValue)
    {
        var type = enumValue.GetType();
        var info = type.GetField(enumValue.ToString());
        var attribute = (EnumMemberAttribute[])info?.GetCustomAttributes(typeof(EnumMemberAttribute), false);
        return attribute?.FirstOrDefault()?.Value;
    }
}