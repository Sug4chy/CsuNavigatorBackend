using CsuNavigatorBackend.Api.Services;
using CsuNavigatorBackend.Api.Validators.Maps;
using CsuNavigatorBackend.ApplicationServices;

namespace CsuNavigatorBackend.Api.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddValidators(this IServiceCollection services)
        => services.AddScoped<EdgeDtoValidator>()
            .AddScoped<CreateMapRequestValidator>();

    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        => services.AddScoped<IMapService, MapService>()
            .AddScoped<IOrganizationService, OrganizationService>();
}