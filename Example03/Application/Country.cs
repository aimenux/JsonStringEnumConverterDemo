using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Example03.Converters;

namespace Example03.Application;

[TypeConverter(typeof(StringEnumConverter<Country>))]
[JsonConverter(typeof(StringEnumJsonConverter<Country>))]
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