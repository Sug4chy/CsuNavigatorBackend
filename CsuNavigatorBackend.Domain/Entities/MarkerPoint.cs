namespace CsuNavigatorBackend.Domain.Entities;

public class MarkerPoint : Entity
{
    public double X { get; set; }
    public double Y { get; set; }
    public MarkerType MarkerType { get; set; }
    public string? Description { get; set; }
    public ICollection<Edge>? EdgesAsPoint1 { get; set; }
    public ICollection<Edge>? EdgesAsPoint2 { get; set; } 
    public Guid MapAsPointWithoutEdgeId { get; set; }
    public Map? MapAsPointWithoutEdge { get; set; }
}

public enum MarkerType
{
    Mobility,
    Room,
    Safety,
    Landmark
}