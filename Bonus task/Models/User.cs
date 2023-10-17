using FileBaseContext.Abstractions.Models.Entity;

namespace Bonus_task.Models;

public class User : IFileSetEntity<Guid>
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
    public string Password { get; set; }

    public User(string firstName, string lastName, string emailAddress, string password)
    {
        Id = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
        EmailAddress = emailAddress;
        Password = password;
    }
}