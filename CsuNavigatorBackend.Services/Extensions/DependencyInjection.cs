using CsuNavigatorBackend.ApplicationServices.Dto;
using CsuNavigatorBackend.ApplicationServices.Services;
using CsuNavigatorBackend.Domain.Entities;
using CsuNavigatorBackend.Services.Mappers;
using CsuNavigatorBackend.Services.Requests.Auth;
using CsuNavigatorBackend.Services.Services;
using CsuNavigatorBackend.Services.Validators.Auth;
using CsuNavigatorBackend.Services.Validators.Dto;
using CsuNavigatorBackend.Services.Validators.Edges;
using CsuNavigatorBackend.Services.Validators.Maps;
using CsuNavigatorBackend.Services.Validators.Points;
using Microsoft.Extensions.DependencyInjection;

namespace CsuNavigatorBackend.Services.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddValidators(this IServiceCollection services)
        => services.AddScoped<PointDtoValidator>()
            .AddScoped<EdgeDtoValidator>()
            .AddScoped<MapDtoValidator>()
            .AddScoped<CreateMapRequestValidator>()
            .AddScoped<CreatePointRequestValidator>()
            .AddScoped<UpdatePointRequestValidator>()
            .AddScoped<CreateEdgeRequestValidator>()
            .AddScoped<MobileRegisterRequestValidator>()
            .AddScoped<LoginRequestValidator>();

    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        => services.AddScoped<IMapService, MapService>()
            .AddScoped<IOrganizationService, OrganizationService>()
            .AddScoped<IPointService, PointService>()
            .AddScoped<IEdgeService, EdgeService>()
            .AddScoped<IAuthService, AuthService>()
            .AddScoped<IProfileService, ProfileService>()
            .AddScoped<ITokenService, TokenService>()
            .AddScoped<IUserService, UserService>()
            .AddScoped<IPasswordHasher, PasswordHasher>();

    public static IServiceCollection AddMappers(this IServiceCollection services)
        => services.AddScoped<IMapper<MarkerPoint, PointDto>, PointMapper>()
            .AddScoped<IMapper<Edge, EdgeDto>, EdgeMapper>()
            .AddScoped<IMapper<Map, MapDto>, MapMapper>()
            .AddScoped<IMapper<MobileRegisterRequest, ProfileDto>, MobileProfileDtoMapper>()
            .AddScoped<IMapper<MobileRegisterRequest, UserDto>, MobileUserDtoMapper>();
}