using Example04.Application;

namespace Example04;

public class Startup
{
    public void ConfigureServices(WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IEmployeeService, EmployeeService>();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddControllers();
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
}