using CsuNavigatorBackend.Domain.Entities;

namespace CsuNavigatorBackend.ApplicationServices.Services;

public interface ITokenService
{
    string CreateJwtForUser(User user);
}