using IdentityDb.Application.Common.Identity.Models;

namespace IdentityDb.Application.Common.Identity.Services;

public interface IAuthService
{
    ValueTask<bool> SignUpAsync(SignUpDetails signUpDetails, CancellationToken cancellationToken = default);

    ValueTask<string> SignInAsync(SignInDetails signInDetails, CancellationToken cancellationToken = default);
}