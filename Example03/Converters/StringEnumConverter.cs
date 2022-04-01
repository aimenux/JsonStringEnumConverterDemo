using System.ComponentModel;
using System.Globalization;
using System.Runtime.Serialization;

namespace Example03.Converters;

public sealed class StringEnumConverter<T> : EnumConverter where T : struct, Enum
{
    public StringEnumConverter() : base(typeof(T))
    {
    }

    static StringEnumConverter()
    {
        Cache.Add(typeof(T), CreateEnumDictionary<T>());
    }

    private static readonly Dictionary<Type, Dictionary<string, Enum>> Cache = new Dictionary<Type, Dictionary<string, Enum>>();

    public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
    {
        return value switch
        {
            null => default,
            string stringValue when Cache[typeof(T)].TryGetValue(stringValue, out var enumValue) => enumValue,
            _ => base.ConvertFrom(context, culture, value)
        };
    }

    public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
    {
        var stringValue = Cache[typeof(T)].FirstOrDefault(x => x.Value.Equals(value)).Key;
        if (stringValue != null)
        {
            return stringValue;
        }

        if (value is T && !Enum.IsDefined(typeof(T), value))
        {
            return value.ToString();
        }

        return base.ConvertTo(context, culture, value, destinationType);
    }

    private static Dictionary<string, Enum> CreateEnumDictionary<TEnumType>()
    {
        return Enum.GetValues(typeof(TEnumType)).Cast<Enum>().ToDictionary(e => ToEnumMember(e) ?? e.ToString(), e => e, StringComparer.OrdinalIgnoreCase);
    }

    private static string ToEnumMember(Enum enumValue)
    {
        var type = enumValue.GetType();
        var info = type.GetField(enumValue.ToString());
        var attribute = (EnumMemberAttribute[])info?.GetCustomAttributes(typeof(EnumMemberAttribute), false);
        return attribute?.FirstOrDefault()?.Value;
    }
}