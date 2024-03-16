using FluentValidation;

namespace CsuNavigatorBackend.Services.Validators.Auth;

public class PasswordValidator : AbstractValidator<string>
{
    public PasswordValidator()
    {
        RuleFor(password => password)
            .NotEmpty()
            .Must(s => s.Select(char.IsDigit).Any())
            .Must(s => s.Select(char.IsUpper).Any())
            .Must(s => s.Select(c => c.IsSpecialSymbol()).Any());
    }
}

public static class CharExtensions
{
    public static bool IsSpecialSymbol(this char c)
    {
        char[] specialSymbols = ['/', '_', '-', '+', '*'];
        return specialSymbols.Contains(c);
    }
}