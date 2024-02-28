namespace CsuNavigatorBackend.Domain.Errors;

public class OrganizationErrors
{
    public static Error NoSuchOrganizationWithName(string name)
        => new(nameof(NoSuchOrganizationWithName), 
            $"There's no such organization with name {name}");
}