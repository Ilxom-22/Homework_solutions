using Identity.Application.Common.Identity.Services;
using BC = BCrypt.Net.BCrypt;

namespace Identity.Infrastructure.Common.Identity.Services;

public class PasswordHasherService : IPasswordHasherService
{
    public string HashPassword(string password)
        => BC.HashPassword(password);

    public bool VerifyPassword(string password, string passwordHash)
        => BC.Verify(password, passwordHash);
}