#pragma warning disable CS8618


using FileBaseContext.Abstractions.Models.Entity;

namespace File_Upload.Models.Entities;

public class User : IFileSetEntity<Guid>
{
    public Guid Id { get; set; }

    public string Username { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string PasswordHash { get; set; }
}