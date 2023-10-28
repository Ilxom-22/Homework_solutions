#pragma warning disable CS8618

namespace Authorization.Api.Models.Identity;

public class LoginDetails
{
    public string EmailAddress { get; set; }

    public string Password { get; set; }
}