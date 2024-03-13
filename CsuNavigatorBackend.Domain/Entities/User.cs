namespace CsuNavigatorBackend.Domain.Entities;

public class User : Entity
{
    public required string Username { get; set; }
    public required string Password { get; set; }
    public string? CurrentRefreshToken { get; set; }
    public DateTime? RefreshTokenExpiration { get; set;}
    public Guid ProfileId { get; set; }
    public Profile? Profile { get; set; }
    public Roles Role { get; set; }
}

public enum Roles
{
    DesktopUser,
    MobileUser
}