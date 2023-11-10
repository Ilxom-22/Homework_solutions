using IdentityDb.Application.Common.Identity.Foundations;
using IdentityDb.Domain.Entities;
using IdentityDb.Persistence.Repositories.Interfaces;

namespace IdentityDb.Infrastructure.Foundations;

public class AccessTokenService : IAccessTokenService
{
    private readonly IAccessTokenRepository _accessTokenRepository;

    public AccessTokenService(IAccessTokenRepository accessTokenRepo) =>
        _accessTokenRepository = accessTokenRepo;

    public async ValueTask<AccessToken> CreateAsync(Guid userId, string value, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var accessToken = new AccessToken
        {
            UserId = userId,
            Value = value,
            CreatedTime = DateTime.UtcNow,
        };

        return await _accessTokenRepository.CreateAsync(accessToken, saveChanges, cancellationToken);
    }
}