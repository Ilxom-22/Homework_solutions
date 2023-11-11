namespace BlogSite.Domain.Entities;

public class User
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = default!;

    public string LastName { get; set; } = default!;

    public string EmailAddress { get; set; } = default!;

    public string PasswordHash { get; set; } = default!;    

    public bool IsEmailAddressVerified { get; set; }
}