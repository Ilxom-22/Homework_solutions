using IdentityDb.Domain.Entities;
using IdentityDb.Persistence.DataContexts;
using IdentityDb.Persistence.Repositories.Interfaces;

namespace IdentityDb.Persistence.Repositories;

public class UserRepository : EntityRepositoryBase<User, IdentityDbContext>, IUserRepository
{
    public UserRepository(IdentityDbContext context) : base(context)
    {
    }
}