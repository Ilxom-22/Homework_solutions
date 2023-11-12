using BlogSite.Domain.Entities;

namespace BlogSite.Application.Common.Identity.Services;

public interface IAccountService
{
    ValueTask<User?> GetUserByEmailAddress(string emailAddress);

    ValueTask<bool> CreateUserAsync(User user, CancellationToken cancellationToken = default);
}