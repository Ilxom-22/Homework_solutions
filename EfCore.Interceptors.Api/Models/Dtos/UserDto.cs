namespace EfCore.Interceptors.Api.Models.Dtos;

public class UserDto
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = default!;
}