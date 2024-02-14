using System.Text.Json;
using Example04.Application;
using FluentAssertions;
using Xunit;

namespace Example04Tests
{
    public class StringEnumJsonConverterTests
    {
        [Theory]
        [InlineData(Country.France, "\"FR\"")]
        [InlineData(Country.Spain, "\"ES\"")]
        [InlineData(Country.Italy, "\"IT\"")]
        [InlineData(Country.Portugal, "\"PT\"")]
        [InlineData((Country)99, "\"99\"")]
        public void EnumToStringTests(Country country, string expected)
        {
            var result = JsonSerializer.Serialize(country);
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
            var result = JsonSerializer.Deserialize<Country>(value);
            result.Should().Be(expected);
        }
    }
}
