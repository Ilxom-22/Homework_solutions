#pragma warning disable CS8618

namespace Identity.Application.Common.Identity.Models;

public class RegistrationDetails
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Username { get; set; }    

    public string EmailAddress { get; set; }

    public string Password { get; set; }    
}