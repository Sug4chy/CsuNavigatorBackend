namespace CsuNavigatorBackend.Domain.Errors;

public static class UserErrors
{
    public static Error UserWithUsernameAlreadyExist(string username)
        => new(nameof(UserWithUsernameAlreadyExist),
            $"User with username {username} already exists");

    public static Error NoSuchUserWithUsername(string username)
        => new(nameof(NoSuchUserWithUsername),
            $"User with username {username} doesn't exist");
}