using BlogSite.Application.Common.Identity.Models;

namespace BlogSite.Application.Common.Identity.Services;

public interface IAuthService
{
    ValueTask<bool> SignUpAsync(SignUpDetails signUpDetails, CancellationToken cancellationToken = default);

    ValueTask<string> SignInAsync(SignInDetails signInDetails, CancellationToken cancellationToken = default);

    ValueTask<bool> GrantRole(Guid userId, string roleType, Guid actionUserId, CancellationToken cancellationToken = default);
}