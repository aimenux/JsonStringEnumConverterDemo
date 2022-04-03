using System.Runtime.Serialization;

namespace Example05.Application;

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