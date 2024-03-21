using CsuNavigatorBackend.Services.Requests.Auth;
using FluentValidation;

namespace CsuNavigatorBackend.Services.Validators.Auth;

public class LoginRequestValidator : AbstractValidator<LoginRequest>
{
    public LoginRequestValidator()
    {
        RuleFor(request => request.Email)
            .NotEmpty();
        RuleFor(request => request.Password)
            .NotEmpty();
    }
}