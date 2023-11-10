using IdentityDb.Domain.Entities;

namespace IdentityDb.Application.Common.Identity.Services;

public interface IAccountService
{
    ValueTask<User?> GetUserByEmailAddress(string emailAddress);

    ValueTask<bool> CreateUserAsync(User user, CancellationToken cancellationToken = default);

    ValueTask<bool> VerificateAsync(string token, CancellationToken cancellationToken = default);
}