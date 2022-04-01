using Example03.Application;
using Example03.Converters;
using FluentAssertions;
using Xunit;

namespace Example03Tests;

public class StringEnumConverterTests
{
    [Theory]
    [InlineData("FRANCE", Country.France)]
    [InlineData("france", Country.France)]
    [InlineData("SPAIN", Country.Spain)]
    [InlineData("spain", Country.Spain)]
    [InlineData("ITALY", Country.Italy)]
    [InlineData("italy", Country.Italy)]
    [InlineData("PORTUGAL", Country.Portugal)]
    [InlineData("portugal", Country.Portugal)]
    [InlineData("FR", Country.France)]
    [InlineData("fr", Country.France)]
    [InlineData("ES", Country.Spain)]
    [InlineData("es", Country.Spain)]
    [InlineData("IT", Country.Italy)]
    [InlineData("it", Country.Italy)]
    [InlineData("PT", Country.Portugal)]
    [InlineData("pt", Country.Portugal)]
    [InlineData("10", Country.France)]
    [InlineData("20", Country.Spain)]
    [InlineData("30", Country.Italy)]
    [InlineData("40", Country.Portugal)]
    [InlineData("99", (Country)99)]
    public void ShouldConvertFromStringToEnum(string stringEnumValue, Country expectedEnumValue)
    {
        // arrange
        var convertor = new StringEnumConverter<Country>();

        // act
        var result = convertor.ConvertFrom(stringEnumValue);

        // assert
        result.Should().Be(expectedEnumValue);
    }

    [Theory]
    [InlineData(Country.France, "FR")]
    [InlineData(Country.Spain, "ES")]
    [InlineData(Country.Italy, "IT")]
    [InlineData(Country.Portugal, "PT")]
    [InlineData((Country)99, "99")]
    public void ShouldConvertFromEnumToString(Country enumValue, string expectedStringEnumValue)
    {
        // arrange
        var convertor = new StringEnumConverter<Country>();

        // act
        var result = convertor.ConvertTo(enumValue, typeof(string)) as string;

        // assert
        result.Should().Be(expectedStringEnumValue);
    }
}