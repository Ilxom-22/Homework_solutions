namespace BlogSite.Application.Common.Dtos;

public class UserDto
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = default!;

    public string LastName { get; set; } = default!;

    public Guid RoleId { get; set; }
}