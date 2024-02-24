namespace CsuNavigatorBackend.Domain.Entities;

public class MarkerPoint : Entity
{
    public double X { get; set; }
    public double Y { get; set; }
    public MarkerType MarkerType { get; set; }
    public string? Description { get; set; }
    public Edge? EdgeAsPoint1 { get; set; }
    public Edge? EdgeAsPoint2 { get; set; } 
}

public enum MarkerType
{
    
}