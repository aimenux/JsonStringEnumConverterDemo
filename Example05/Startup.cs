using Example05.Application;
using Example05.Converters;
using Microsoft.AspNetCore.Mvc;

namespace Example05;

public class Startup
{
    public void ConfigureServices(WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IEmployeeService, EmployeeService>();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services
            .AddControllers()
            .AddTypeConverters()
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
        options.JsonSerializerOptions.Converters.Add(new StringEnumJsonConverter<Country>());
    }
}