using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Example04.Converters;

namespace Example04.Application;

[TypeConverter(typeof(StringEnumConverter<Country>))]
[JsonConverter(typeof(JsonStringEnumConverter<Country>))]
public enum Country
{
    [EnumMember(Value = "FR")]
    France = 10,

    [EnumMember(Value = "ES")]
    Spain = 20,

    [EnumMember(Value = "IT")]
    Italy = 30,

    [EnumMember(Value = "PT")]
    Portugal = 40
}