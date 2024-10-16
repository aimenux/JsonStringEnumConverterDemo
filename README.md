[![.NET](https://github.com/aimenux/JsonStringEnumConverterDemo/actions/workflows/ci.yml/badge.svg?branch=main)](https://github.com/aimenux/JsonStringEnumConverterDemo/actions/workflows/ci.yml)

# JsonStringEnumConverterDemo
```
Using various ways to support serialization/deserialization and model binding of enums in web api
```

In this demo, i m using various ways in order to support serialization/deserialization and model binding of enums (with or without [EnumMemberAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.serialization.enummemberattribute)) in web api using [System.Text.Json](https://docs.microsoft.com/en-us/dotnet/api/system.text.json) :
>
:one: `Example01` : Use locally `JsonStringEnumConverter` to support serialization/deserialization and model binding of enums (without `EnumMemberAttribute`)
>
:two: `Example02` : Use globally `JsonStringEnumConverter` to support serialization/deserialization and model binding of enums (without `EnumMemberAttribute`)
>
:three: `Example03` : Use locally custom json converter to support serialization/deserialization and custom type converter to support model binding of enums (with `EnumMemberAttribute`)
>
:four: `Example04` : Use locally custom json converter (another implementation) to support serialization/deserialization and custom type converter to support model binding of enums (with `EnumMemberAttribute`)
>
:five: `Example05` : Use globally custom json converter to support serialization/deserialization and custom type converter to support model binding of enums (with `EnumMemberAttribute`)

**`Tools`** : net 8.0, xunit, fluent-assertions