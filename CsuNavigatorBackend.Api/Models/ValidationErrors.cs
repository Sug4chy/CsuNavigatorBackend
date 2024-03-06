using CsuNavigatorBackend.Domain.Errors;

namespace CsuNavigatorBackend.Api.Models;

public static class ValidationErrors
{
    public static readonly Error EmptyGuid = new Error(nameof(EmptyGuid), 
        $"Guid must to be non equal to {Guid.Empty}");
}