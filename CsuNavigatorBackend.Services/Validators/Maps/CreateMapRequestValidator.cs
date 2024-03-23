using CsuNavigatorBackend.Services.Requests.Maps;
using CsuNavigatorBackend.Services.Validators.Dto;
using FluentValidation;

namespace CsuNavigatorBackend.Services.Validators.Maps;

public class CreateMapRequestValidator : AbstractValidator<CreateMapRequest>
{
    public CreateMapRequestValidator(MapDtoValidator mapDtoValidator)
    {
        RuleFor(request => request.Map)
            .SetValidator(mapDtoValidator);
        RuleFor(request => request.OrganizationName)
            .NotEmpty();
    }
}