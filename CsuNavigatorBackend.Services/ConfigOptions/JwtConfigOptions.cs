namespace CsuNavigatorBackend.Services.ConfigOptions;

public class JwtConfigOptions
{
    public const string Location = "JwtConfiguration";

    public string Issuer { get; set; } = string.Empty;
    public string Audience { get; set; } = string.Empty;
    public string SymmetricSecurityKey { get; set; } = string.Empty;
    public int JwtExpiresTimeHours { get; set; }
}