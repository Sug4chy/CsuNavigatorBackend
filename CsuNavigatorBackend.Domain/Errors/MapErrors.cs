namespace CsuNavigatorBackend.Domain.Errors;

public static class MapErrors
{
    public static Error NoSuchMapWithId(Guid id)
        => new(nameof(NoSuchMapWithId), $"Map with id {id} doesn't exist!");
    
    public static Error MapWithSuchNameAlreadyExists(String name)
        => new(nameof(MapWithSuchNameAlreadyExists), $"map with name {name} already exists");

}