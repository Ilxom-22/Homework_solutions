#pragma warning disable CS8618

namespace Authorization.Api.Models.Identity;

public class RegistrationDetails
{
    public string FirstName { get; set; }   

    public string LastName { get; set; }

    public string EmailAddress { get; set; }

    public string PhoneNumber { get; set; }

    public string Password { get; set; }
}