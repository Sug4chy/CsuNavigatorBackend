using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;

namespace CsuNavigatorBackend.Web.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddSwaggerWithAuth(this IServiceCollection services)
        => services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo { Title = "CsuNavigatorBackend", Version = "v1" });
            options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme,
                new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please, insert your token: ",
                    Name = "SchemeWithJwtAuth",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = JwtBearerDefaults.AuthenticationScheme
                });
            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = JwtBearerDefaults.AuthenticationScheme
                        }
                    },
                    []
                }
            });
        });
}