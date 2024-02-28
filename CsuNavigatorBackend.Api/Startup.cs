using CsuNavigatorBackend.Api.Extensions;
using CsuNavigatorBackend.Database.Context;
using CsuNavigatorBackend.Database.Context.Interceptors;
using Microsoft.EntityFrameworkCore;

namespace CsuNavigatorBackend.Api;

public class Startup(IConfiguration config, IWebHostEnvironment env)
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<UpdateAuditableEntitiesInterceptor>();
        services.AddDbContext<NavigatorDbContext>((provider, builder) =>
        {
            var updateAuditableEntitiesInterceptor = provider
                .GetRequiredService<UpdateAuditableEntitiesInterceptor>();
            builder.UseNpgsql(config.GetConnectionString("DefaultConnection"))
                .AddInterceptors(updateAuditableEntitiesInterceptor);
        });
        
        services.AddControllers();
        services.AddValidators();
        services.AddApplicationServices();
        
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

        //app.UseHttpsRedirection();
        app.UseRouting();
        
        app.UseAuthorization();
        
        app.UseEndpoints(builder => builder.MapControllers());
    }
}