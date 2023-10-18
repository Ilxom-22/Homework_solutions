using FileBaseContext.Abstractions.Models.Entity;

namespace Photogram.Entities;

public class User : IFileSetEntity<Guid>
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
    public string Password { get; set; }
    public string ProfileImagePath { get; set; }

    public User(string firstName, string lastName, string emailAddress, string password, string profileImagePath)
    {
        Id = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
        EmailAddress = emailAddress;
        Password = password;
        ProfileImagePath = profileImagePath;
    }
}