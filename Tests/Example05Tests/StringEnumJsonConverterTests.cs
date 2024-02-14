using System.ComponentModel;
using System.Text.Json;
using Example05.Application;
using Example05.Converters;
using FluentAssertions;
using Xunit;

namespace Example05Tests
{
    public class StringEnumJsonConverterTests
    {
        public StringEnumJsonConverterTests()
        {
            TypeDescriptor.AddAttributes(typeof(Country), new TypeConverterAttribute(typeof(StringEnumConverter<Country>)));
        }

        [Theory]
        [InlineData(Country.France, "\"FR\"")]
        [InlineData(Country.Spain, "\"ES\"")]
        [InlineData(Country.Italy, "\"IT\"")]
        [InlineData(Country.Portugal, "\"PT\"")]
        [InlineData((Country)99, "\"99\"")]
        public void EnumToStringTests(Country country, string expected)
        {
            var options = new JsonSerializerOptions();
            options.Converters.Add(new StringEnumJsonConverter<Country>());
            var result = JsonSerializer.Serialize(country, options);
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("\"FR\"", Country.France)]
        [InlineData("\"ES\"", Country.Spain)]
        [InlineData("\"IT\"", Country.Italy)]
        [InlineData("\"PT\"", Country.Portugal)]
        [InlineData("\"99\"", (Country)99)]
        [InlineData("null", default(Country))]
        public void StringToEnumTests(string value, Country expected)
        {
            var options = new JsonSerializerOptions();
            options.Converters.Add(new StringEnumJsonConverter<Country>());
            var result = JsonSerializer.Deserialize<Country>(value, options);
            result.Should().Be(expected);
        }
    }
}
