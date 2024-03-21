namespace CsuNavigatorBackend.Domain.Errors;

public static class AuthErrors
{
    public static Error InvalidPassword => new(nameof(InvalidPassword),
        $"Password is invalid");
}