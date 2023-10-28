#pragma warning disable CS8618

namespace Authorization.Api.Models.Entities;

public class User
{
    public Guid Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string EmailAddress { get; set; }

    public string PhoneNumber { get; set; }

    public string Password { get; set; }    
}