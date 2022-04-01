using Example02.Application;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace Example02;

public class Startup
{
    public void ConfigureServices(WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IEmployeeService, EmployeeService>();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services
            .AddControllers()
            .AddJsonOptions(ConfigureJsonSerializerOptions);
    }

    public void Configure(WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();
    }

    private static void ConfigureJsonSerializerOptions(JsonOptions options)
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    }
}