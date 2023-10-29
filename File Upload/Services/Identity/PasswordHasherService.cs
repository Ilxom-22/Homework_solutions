using BC = BCrypt.Net.BCrypt;

namespace File_Upload.Services.Identity;

public class PasswordHasherService
{
    public string HashPassword(string password)
        => BC.HashPassword(password);

    public bool VerifyPassword(string password, string hashedPassword)
        => BC.Verify(password, hashedPassword);
}