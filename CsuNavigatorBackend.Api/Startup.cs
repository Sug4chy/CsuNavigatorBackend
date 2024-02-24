namespace CsuNavigatorBackend.Api;

public class Startup(IWebHostEnvironment env)
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddAuthorization();

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }

    public void Configure(IApplicationBuilder app)
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();
    }
}