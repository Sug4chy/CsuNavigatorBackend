using CsuNavigatorBackend.Database.Context;
using CsuNavigatorBackend.Database.Context.Interceptors;
using CsuNavigatorBackend.Services.ConfigOptions;
using CsuNavigatorBackend.Services.Extensions;
using CsuNavigatorBackend.Web.Extensions;
using Microsoft.EntityFrameworkCore;

namespace CsuNavigatorBackend.Web;

public class Startup(IConfiguration config, IWebHostEnvironment env)
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.Configure<JwtConfigOptions>(config
            .GetSection(JwtConfigOptions.Location));
        
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
        services.AddMappers();

        services.AddJwtAuthentication(config);
        services.AddAuthorization();

        services.AddEndpointsApiExplorer();
        services.AddSwaggerWithAuth();

        services.AddErrorHandling();
    }

    public void Configure(IApplicationBuilder app)
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseRouting();
        app.UseErrorHandling();
        
        app.UseAuthorization();
        
        app.UseEndpoints(builder => builder.MapControllers());
    }
}