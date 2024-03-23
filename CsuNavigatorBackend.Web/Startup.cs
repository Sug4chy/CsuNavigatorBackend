using System.Security.Claims;
using CsuNavigatorBackend.Database.Context;
using CsuNavigatorBackend.Database.Context.Interceptors;
using CsuNavigatorBackend.Domain.Entities;
using CsuNavigatorBackend.Services.ConfigOptions;
using CsuNavigatorBackend.Services.Extensions;
using CsuNavigatorBackend.Web.Auth;
using CsuNavigatorBackend.Web.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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

        services.AddHttpContextAccessor();
        services.AddCurrentUserAccessor();
        services.AddControllers();
        services.AddValidators();
        services.AddApplicationServices();
        services.AddMappers();

        services.AddJwtAuthentication(config);
        services.AddAuthorization(auth =>
        {
            auth.AddPolicy(Policies.OnlyAdmins, policy => 
                policy.RequireClaim(ClaimTypes.Role, Role.AdminUser.ToString()));
            auth.AddPolicy(Policies.OnlyDesktopUsers, policy => 
                policy.RequireClaim(ClaimTypes.Role, Role.DesktopUser.ToString()));
            
            auth.AddPolicy(Policies.BearerDefault, new AuthorizationPolicyBuilder()
                .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                .RequireAuthenticatedUser()
                .Build());
            auth.DefaultPolicy = auth.GetPolicy(Policies.BearerDefault)!;
        });

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