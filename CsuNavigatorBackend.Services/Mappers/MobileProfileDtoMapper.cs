using CsuNavigatorBackend.ApplicationServices.Dto;
using CsuNavigatorBackend.ApplicationServices.Services;
using CsuNavigatorBackend.Services.Requests.Auth;

namespace CsuNavigatorBackend.Services.Mappers;

public class MobileProfileDtoMapper : IMapper<MobileRegisterRequest, ProfileDto>
{
    public ProfileDto Map(MobileRegisterRequest from)
        => new()
        {
            Name = from.Name,
            Surname = from.Surname,
            Patronymic = from.Patronymic
        };
}