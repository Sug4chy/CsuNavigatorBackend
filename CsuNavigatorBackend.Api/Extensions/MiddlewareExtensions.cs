using CsuNavigatorBackend.Api.Middlewares;

namespace CsuNavigatorBackend.Api.Extensions;

public static class MiddlewareExtensions
{
    public static IServiceCollection AddErrorHandling(this IServiceCollection services)
        => services.AddSingleton<ErrorHandlingMiddleware>();

    public static IApplicationBuilder UseErrorHandling(this IApplicationBuilder app)
        => app.UseMiddleware<ErrorHandlingMiddleware>();
}