namespace CsuNavigatorBackend.Domain.Errors;

public static class MarkerPointErrors
{
    public static Error NoSuchPointWithId(Guid id)
        => new(nameof(NoSuchPointWithId), 
            $"Marker point with id {id} doesn't exist");
}