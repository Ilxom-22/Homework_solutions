#pragma warning disable CS8618

namespace Library.Domain.Entities;

public class Author
{
    public Guid Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }
}