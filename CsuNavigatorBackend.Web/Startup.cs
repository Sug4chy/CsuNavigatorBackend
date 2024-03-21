using System.Text;
using CsuNavigatorBackend.Database.Context;
using CsuNavigatorBackend.Database.Context.Interceptors;
using CsuNavigatorBackend.Services.ConfigOptions;
using CsuNavigatorBackend.Services.Extensions;
using CsuNavigatorBackend.Web.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

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

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                var jwtOptions = config.GetSection(JwtConfigOptions.Location);
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = jwtOptions.GetValue<string>("Issuer"),
                    ValidateAudience = true,
                    ValidAudience = jwtOptions.GetValue<string>("Audience"),
                    ValidateLifetime = true,
                    IssuerSigningKey =
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                            jwtOptions.GetValue<string>("SymmetricSecurityKey")!)),
                    ValidateIssuerSigningKey = true
                };
            });
        services.AddAuthorization();

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

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