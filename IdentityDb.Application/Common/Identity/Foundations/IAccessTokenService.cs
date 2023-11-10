using IdentityDb.Domain.Entities;

namespace IdentityDb.Application.Common.Identity.Foundations;

public interface IAccessTokenService
{
    ValueTask<AccessToken> CreateAsync(
        Guid userId,
        string value,
        bool saveChanges = true,
        CancellationToken cancellationToken = default
    );
}