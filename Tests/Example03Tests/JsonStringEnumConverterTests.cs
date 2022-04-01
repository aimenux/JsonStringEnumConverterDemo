using System.Text.Json;
using Example03.Application;
using Xunit;

namespace Example03Tests
{
    public class JsonStringEnumConverterTests
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
            Assert.Equal(expected, result);
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
            Assert.Equal(expected, result);
        }
    }
}
