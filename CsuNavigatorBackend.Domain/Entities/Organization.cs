namespace CsuNavigatorBackend.Domain.Entities;

public class Organization : Entity
{
    public required string Name { get; set; }
    
    public ICollection<Profile>? WorkersProfiles { get; set; }
    
    public ICollection<Map>? Maps { get; set; }
}