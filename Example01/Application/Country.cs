using System.Text.Json.Serialization;

namespace Example01.Application;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Country
{
    France = 10,
    Spain = 20,
    Italy = 30,
    Portugal = 40
}