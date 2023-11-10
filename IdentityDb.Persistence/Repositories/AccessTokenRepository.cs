using IdentityDb.Domain.Entities;
using IdentityDb.Persistence.DataContexts;
using IdentityDb.Persistence.Repositories.Interfaces;

namespace IdentityDb.Persistence.Repositories;

public class AccessTokenRepository : EntityRepositoryBase<AccessToken, IdentityDbContext>, IAccessTokenRepository
{
    public AccessTokenRepository(IdentityDbContext context) : base(context)
    {
    }
}