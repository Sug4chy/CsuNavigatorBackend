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
public class AuthController(
    IAuthService authService,
    IUserService userService) : ControllerBase
{
    [HttpPost("register/mobile")]
    public async Task<MobileRegisterResponse> MobileRegister(
        [FromBody] MobileRegisterRequest request,
        [FromServices] MobileRegisterRequestValidator validator,
        [FromServices] IMapper<MobileRegisterRequest, UserDto> mobileUserDtoMapper,
        [FromServices] IMapper<MobileRegisterRequest, ProfileDto> mobileProfileDtoMapper,
        CancellationToken ct = default)
    {
        var validationResult = await validator.ValidateAsync(request, ct);
        BadRequestException.ThrowByValidationResult(validationResult);

        var user = await userService.CreateUserAsync(mobileUserDtoMapper.Map(request), ct)
            ?? throw new ConflictException
            {
                Error = UserErrors.UserWithUsernameAlreadyExist(request.Username)
            };
        
        string token = await authService.RegisterMobileUserAsync(user, mobileProfileDtoMapper.Map(request), ct);
        
        return new MobileRegisterResponse
        {
            Jwt = token
        };
    }
}