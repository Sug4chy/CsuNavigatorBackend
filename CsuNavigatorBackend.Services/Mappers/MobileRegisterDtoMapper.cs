using CsuNavigatorBackend.ApplicationServices.Dto;
using CsuNavigatorBackend.ApplicationServices.Services;
using CsuNavigatorBackend.Services.Requests.Auth;

namespace CsuNavigatorBackend.Services.Mappers;

public class MobileRegisterDtoMapper : IMapper<MobileRegisterRequest, MobileRegisterDto>
{
    public MobileRegisterDto Map(MobileRegisterRequest from)
        => new()
        {
            Name = from.Name,
            Surname = from.Surname,
            Patronymic = from.Patronymic,
            Username = from.Username,
            Password = from.Password
        };
}