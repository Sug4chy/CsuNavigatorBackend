using CsuNavigatorBackend.ApplicationServices.Dto;
using CsuNavigatorBackend.ApplicationServices.Services;
using CsuNavigatorBackend.Domain.Entities;

namespace CsuNavigatorBackend.Services.Mappers;

public class MobileUserDtoMapper : IMapper<MobileRegisterDto, UserDto>
{
    public UserDto Map(MobileRegisterDto from)
        => new()
        {
            Username = from.Username,
            Password = from.Password,
            Role = Role.MobileUser
        };
}