using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Example05Tests;

public class EmployeeControllerTests : IClassFixture<ApiWebApplicationFactory>
{
    private readonly ApiWebApplicationFactory _factory;

    public EmployeeControllerTests(ApiWebApplicationFactory factory)
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
    [InlineData("FR", "FR")]
    [InlineData("fr", "FR")]
    [InlineData("ES", "ES")]
    [InlineData("es", "ES")]
    [InlineData("IT", "IT")]
    [InlineData("it", "IT")]
    [InlineData("PT", "PT")]
    [InlineData("pt", "PT")]
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