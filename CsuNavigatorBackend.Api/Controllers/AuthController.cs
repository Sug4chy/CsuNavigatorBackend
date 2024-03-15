using CsuNavigatorBackend.Api.Exceptions;
using CsuNavigatorBackend.Api.Responses.Auth;
using CsuNavigatorBackend.ApplicationServices.Dto;
using CsuNavigatorBackend.ApplicationServices.Services;
using CsuNavigatorBackend.Domain.Errors;
using CsuNavigatorBackend.Services.Requests.Auth;
using CsuNavigatorBackend.Services.Validators.Auth;
using Microsoft.AspNetCore.Mvc;

namespace CsuNavigatorBackend.Api.Controllers;

[ApiController]
[Route("/[controller]")]
public class AuthController(IAuthService authService) : ControllerBase
{
    [HttpPost("register/mobile")]
    public async Task<RegisterResponse> Register(
        [FromBody] MobileRegisterRequest request,
        [FromServices] MobileRegisterRequestValidator validator,
        [FromServices] IMapper<MobileRegisterRequest, MobileRegisterDto> mobileRegisterDtoMapper,
        CancellationToken ct = default)
    {
        var validationResult = await validator.ValidateAsync(request, ct);
        BadRequestException.ThrowByValidationResult(validationResult);

        string token = await authService.RegisterMobileUserAsync(mobileRegisterDtoMapper.Map(request), ct);
        if (token.Length == 0)
        {
            throw new ConflictException
            {
                Error = UserErrors.UserWithUsernameAlreadyExist(request.Username)
            };
        }
        
        return new RegisterResponse
        {
            Jwt = token
        };
    }
}