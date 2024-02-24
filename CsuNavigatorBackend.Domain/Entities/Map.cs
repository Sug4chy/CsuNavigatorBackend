namespace CsuNavigatorBackend.Domain.Entities;

public class Map : Entity
{
    public required string Title { get; set; }
    public string? Description { get; set; }
    
    public Guid OrganizationId { get; set; }
    public Organization? Organization { get; set; }
    
    public Guid? ImageId { get; set; }
    public Image? Image { get; set; }
    
    public ICollection<Edge>? Edges { get; set; }
}