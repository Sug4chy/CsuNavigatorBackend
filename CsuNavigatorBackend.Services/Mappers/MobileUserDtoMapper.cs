using CsuNavigatorBackend.ApplicationServices.Dto;
using CsuNavigatorBackend.ApplicationServices.Services;
using CsuNavigatorBackend.Domain.Entities;
using CsuNavigatorBackend.Services.Requests.Auth;

namespace CsuNavigatorBackend.Services.Mappers;

public class MobileUserDtoMapper : IMapper<MobileRegisterRequest, UserDto>
{
    public UserDto Map(MobileRegisterRequest from)
        => new()
        {
            Username = from.Username,
            Password = from.Password,
            Role = Role.MobileUser
        };
}