using CsuNavigatorBackend.ApplicationServices.Dto;
using CsuNavigatorBackend.ApplicationServices.Services;
using CsuNavigatorBackend.Domain.Errors;
using CsuNavigatorBackend.Services.Requests.Auth;
using CsuNavigatorBackend.Services.Validators.Auth;
using CsuNavigatorBackend.Web.Auth;
using CsuNavigatorBackend.Web.Exceptions;
using CsuNavigatorBackend.Web.Responses.Auth;
using Microsoft.AspNetCore.Mvc;

namespace CsuNavigatorBackend.Web.Controllers;

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

    [HttpPost("login")]
    public async Task<LoginResponse> Login(
        [FromBody] LoginRequest request,
        [FromServices] LoginRequestValidator validator,
        CancellationToken ct = default)
    {
        var validationResult = await validator.ValidateAsync(request, ct);
        BadRequestException.ThrowByValidationResult(validationResult);

        var user = await userService.GetUserByUsernameAndRoleAsync(request.Email, request.LoginSource,  ct);
        NotFoundException.ThrowIfNull(user, UserErrors.NoSuchUserWithUsername(request.Email));

        string token = authService.LoginUser(user!, request.Password);
        if (token.Length == 0)
        {
            throw new UnauthorizedException
            {
                Error = AuthErrors.InvalidPassword
            };
        }

        return new LoginResponse
        {
            Jwt = token
        };
    }
}