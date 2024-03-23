namespace CsuNavigatorBackend.Web.Auth;

public static class Policies
{
    public const string BearerDefault = "BearerDefault";
    
    public const string OnlyAdmins = "OnlyAdmins";
    public const string OnlyDesktopUsers = "OnlyDesktopUsers";
}