namespace CsuNavigatorBackend.Domain.Errors;

public static class EdgeErrors
{
    public static Error NoSuchEdgeWithId(Guid id)
        => new(nameof(NoSuchEdgeWithId), $"Edge with id {id} doesn't exist");
    
    public static Error EdgeWithSuchPointsAlreadyExists(Guid point1Id, Guid point2Id)
        => new(nameof(EdgeWithSuchPointsAlreadyExists), $"Edge with points {point1Id}, {point2Id} already exists");

}