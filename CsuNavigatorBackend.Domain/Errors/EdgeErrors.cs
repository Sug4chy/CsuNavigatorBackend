namespace CsuNavigatorBackend.Domain.Errors;

public static class EdgeErrors
{
    public static Error NoSuchEdgeWithId(Guid id)
        => new(nameof(NoSuchEdgeWithId), $"Edge with id {id} doesn't exist");
}