namespace BlogSite.Application.Common.Identity.Services;
public interface IPasswordHasherService
{
    string HashPassword(string password);

    bool VerifyPassword(string password, string passwordHash);
}