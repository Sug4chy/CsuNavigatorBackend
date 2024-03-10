using CsuNavigatorBackend.Services.Requests.Maps;
using CsuNavigatorBackend.Services.Validators.Dto;
using FluentValidation;

namespace CsuNavigatorBackend.Services.Validators.Maps;

public class CreateMapRequestValidator : AbstractValidator<CreateMapRequest>
{
    public CreateMapRequestValidator()
    {
        RuleFor(request => request.Map)
            .SetValidator(new MapDtoValidator());
        RuleFor(request => request.OrganizationName)
            .NotEmpty();
    }
}