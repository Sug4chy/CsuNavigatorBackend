using CsuNavigatorBackend.Services.Requests.Points;
using CsuNavigatorBackend.Services.Validators.Dto;
using FluentValidation;

namespace CsuNavigatorBackend.Services.Validators.Points;

public class UpdatePointRequestValidator : AbstractValidator<UpdatePointRequest>
{
    public UpdatePointRequestValidator()
    {
        RuleFor(request => request.UpdatedPoint)
            .SetValidator(new PointDtoValidator());
    }
}