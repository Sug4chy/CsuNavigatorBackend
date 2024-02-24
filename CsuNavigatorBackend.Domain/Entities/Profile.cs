namespace CsuNavigatorBackend.Domain.Entities;

public class Profile : Entity
{
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public string? Patronymic { get; set; }
    
    public User? User { get; set; }
    
    public Guid? AvatarId { get; set; }
    public Image? Avatar { get; set; }
    
    public ICollection<Organization>? AllowedOrganizations { get; set; }
}