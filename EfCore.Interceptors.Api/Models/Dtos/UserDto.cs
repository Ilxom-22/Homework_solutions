using EfCore.Interceptors.Domain.Constants;

namespace EfCore.Interceptors.Api.Models.Dtos;

public class UserDto
{
    public Guid Id { get; set; }

    public string UserName { get; set; } = default!;

    public RoleType Role { get; set; }
}