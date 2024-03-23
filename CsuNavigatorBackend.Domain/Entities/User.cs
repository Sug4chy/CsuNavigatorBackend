namespace CsuNavigatorBackend.Domain.Entities;

public class User : Entity
{
    public required string Username { get; set; }
    public required string Password { get; set; }
    public Guid ProfileId { get; set; }
    public Profile? Profile { get; set; }
    public Role Role { get; set; }
}

public enum Role
{
    DesktopUser,
    MobileUser,
    AdminUser
}