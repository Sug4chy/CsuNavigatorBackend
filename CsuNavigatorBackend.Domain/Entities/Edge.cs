namespace CsuNavigatorBackend.Domain.Entities;

public class Edge : Entity
{
    public Guid Point1Id { get; set; }
    public MarkerPoint? Point1 { get; set; }
    
    public Guid Point2Id { get; set; }
    public MarkerPoint? Point2 { get; set; }
    
    public Guid MapId { get; set; }
    public Map? Map { get; set; }
}