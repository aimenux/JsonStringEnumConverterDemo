using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Example02Tests;

public class EmployeeControllerTests : IClassFixture<CustomWebApplicationFactory>
{
    private readonly CustomWebApplicationFactory _factory;

    public EmployeeControllerTests(CustomWebApplicationFactory factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task ShouldGetEmployees()
    {
        // arrange
        var client = _factory.CreateClient();

        // act
        var response = await client.GetAsync("/employee");

        // assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Theory]
    [InlineData("France", "France")]
    [InlineData("FRANCE", "France")]
    [InlineData("Spain", "Spain")]
    [InlineData("SPAIN", "Spain")]
    [InlineData("Italy", "Italy")]
    [InlineData("ITALY", "Italy")]
    [InlineData("Portugal", "Portugal")]
    [InlineData("PORTUGAL", "Portugal")]
    public async Task ShouldGetEmployeesForValidCountry(string country, string expectedSerializedCountry)
    {
        // arrange
        var client = _factory.CreateClient();

        // act
        var response = await client.GetAsync($"/employee?country={country}");
        var content = await response.Content.ReadAsStringAsync();

        // assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        content.Should().Contain($"\"country\":\"{expectedSerializedCountry}\"");
    }

    [Theory]
    [InlineData("FRA!")]
    [InlineData("SPA!")]
    [InlineData("ITA!")]
    [InlineData("POR!")]
    public async Task ShouldGetBadRequestForInvalidCountry(string country)
    {
        // arrange
        var client = _factory.CreateClient();

        // act
        var response = await client.GetAsync($"/employee?country={country}");

        // assert
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }
}