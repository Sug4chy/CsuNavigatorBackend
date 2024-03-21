using CsuNavigatorBackend.ApplicationServices.Dto;
using FluentValidation;

namespace CsuNavigatorBackend.Services.Validators.Dto;

public class EdgeDtoValidator : AbstractValidator<EdgeDto>
{
    public EdgeDtoValidator(PointDtoValidator pointDtoValidator)
    {
        RuleFor(dto => dto.Id)
            .Null();
        RuleFor(dto => dto.Point1)
            .SetValidator(pointDtoValidator);
        RuleFor(dto => dto.Point2)
            .SetValidator(pointDtoValidator);
    }
}