using CsuNavigatorBackend.Services.Requests.Maps;
using FluentValidation;

namespace CsuNavigatorBackend.Services.Validators.Maps;

public class UpdateMapRequestValidator : AbstractValidator<UpdateMapRequest>
{
    public UpdateMapRequestValidator()
    {
        RuleFor(request => request.NewTitle)
            .NotEmpty();
        RuleFor(request => request.NewDescription)
            .Must(s => s is null || s.Length != 0);
    }
}