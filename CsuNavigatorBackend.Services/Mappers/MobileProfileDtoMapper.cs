using CsuNavigatorBackend.ApplicationServices.Dto;
using CsuNavigatorBackend.ApplicationServices.Services;

namespace CsuNavigatorBackend.Services.Mappers;

public class MobileProfileDtoMapper : IMapper<MobileRegisterDto, ProfileDto>
{
    public ProfileDto Map(MobileRegisterDto from)
        => new()
        {
            Name = from.Name,
            Surname = from.Surname,
            Patronymic = from.Patronymic
        };
}