using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CsuNavigatorBackend.ApplicationServices.Services;
using CsuNavigatorBackend.Domain.Entities;
using CsuNavigatorBackend.Services.ConfigOptions;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace CsuNavigatorBackend.Services.Services;

public class TokenService(IOptions<JwtConfigOptions> options) : ITokenService
{
    private readonly JwtConfigOptions _jwtConfigOptions = options.Value;

    public string CreateJwtForUser(User user)
    {
        Claim[] claims =
        [
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.UserData, user.Username),
            new Claim(ClaimTypes.Name, user.Profile!.Name),
            new Claim(ClaimTypes.Surname, user.Profile.Surname)
        ];

        var jwt = new JwtSecurityToken(
            issuer: _jwtConfigOptions.Issuer,
            audience: _jwtConfigOptions.Audience,
            claims: claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromHours(_jwtConfigOptions.JwtExpiresTimeHours)),
            signingCredentials: new SigningCredentials(GetSymmetricSecurityKey(), 
                SecurityAlgorithms.HmacSha256));

        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }

    private SymmetricSecurityKey GetSymmetricSecurityKey()
        => new(Encoding.UTF8.GetBytes(_jwtConfigOptions.SymmetricSecurityKey));
}