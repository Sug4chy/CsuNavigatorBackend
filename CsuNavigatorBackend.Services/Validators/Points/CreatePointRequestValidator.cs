using CsuNavigatorBackend.Services.Requests.Points;
using CsuNavigatorBackend.Services.Validators.Dto;
using FluentValidation;

namespace CsuNavigatorBackend.Services.Validators.Points;

public class CreatePointRequestValidator : AbstractValidator<CreatePointRequest>
{
    public CreatePointRequestValidator()
    {
        RuleFor(request => request.Point)
            .SetValidator(new PointDtoValidator());
    }
}