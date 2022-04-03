# JsonStringEnumConverterDemo
```
Using various ways to support serialization/deserialization and model binding of enums in web api
```

In this demo, i m using various ways in order to suppport serialization/deserialization and model binding of enums (with/without [EnumMemberAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.serialization.enummemberattribute)) in web api using [System.Text.Json](https://docs.microsoft.com/en-us/dotnet/api/system.text.json) :
>
:one: `Example01` : Use localy `JsonStringEnumConverter` to support serialization/deserialization and model binding of enums (without `EnumMemberAttribute`)
>
:two: `Example02` : Use globaly `JsonStringEnumConverter` to support serialization/deserialization and model binding of enums (without `EnumMemberAttribute`)
>
:three: `Example03` : Use localy custom json converter to support serialization/deserialization and custom type converter to support model binding of enums (with `EnumMemberAttribute`)
>
:four: `Example04` : Use localy custom json converter (another implementation) to support serialization/deserialization and custom type converter to support model binding of enums (with `EnumMemberAttribute`)
>
:five: `Example05` : Use globaly custom json converter to support serialization/deserialization and custom type converter to support model binding of enums (with `EnumMemberAttribute`)

**`Tools`** : vs22, net 6.0, xunit, fluent-assertions