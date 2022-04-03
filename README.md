# JsonStringEnumConverterDemo
```
Using various ways to support enums in serialization/deserialization and model binding of requests/responses in web api
```

In this demo, i m using various ways in order to suppport enums (with/without [EnumMemberAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.serialization.enummemberattribute)) in serialization/deserialization and model binding of requests/responses in web api using [System.Text.Json](https://docs.microsoft.com/en-us/dotnet/api/system.text.json) :
>
:one: `Example01` : Use localy `JsonStringEnumConverter` to support serialization/deserialization and model binding of enums (without [EnumMemberAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.serialization.enummemberattribute))
>
:two: `Example02` : Use globaly `JsonStringEnumConverter` to support serialization/deserialization and model binding of enums (without [EnumMemberAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.serialization.enummemberattribute))
>
:three: `Example03` : Use localy custom json converter to support serialization/deserialization and custom type converter to support model binding of enums (with [EnumMemberAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.serialization.enummemberattribute))
>
:four: `Example04` : Use localy custom json converter (another implementation) to support serialization/deserialization and custom type converter to support model binding of enums (with [EnumMemberAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.serialization.enummemberattribute))
>
:five: `Example05` : Use globaly custom json converter to support serialization/deserialization and custom type converter to support model binding of enums (with [EnumMemberAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.serialization.enummemberattribute))

**`Tools`** : vs22, net 6.0, xunit, fluent-assertions