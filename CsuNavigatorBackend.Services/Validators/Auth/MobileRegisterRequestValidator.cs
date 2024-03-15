using CsuNavigatorBackend.Services.Requests.Auth;
using FluentValidation;

namespace CsuNavigatorBackend.Services.Validators.Auth;

public class MobileRegisterRequestValidator : AbstractValidator<MobileRegisterRequest>
{
    public MobileRegisterRequestValidator()
    {
        RuleFor(request => request.Name)
            .NotEmpty();
        RuleFor(request => request.Surname)
            .NotEmpty();
        RuleFor(request => request.Patronymic)
            .Must(s => s is null || s.Length != 0);
        RuleFor(request => request.Username)
            .NotEmpty();
        RuleFor(request => request.Password)
            .NotEmpty();
    }
}