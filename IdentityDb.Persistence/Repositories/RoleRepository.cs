using IdentityDb.Domain.Entities;
using IdentityDb.Persistence.DataContexts;
using IdentityDb.Persistence.Repositories.Interfaces;
using System.Linq.Expressions;

namespace IdentityDb.Persistence.Repositories;

public class RoleRepository : EntityRepositoryBase<Role, IdentityDbContext>, IRoleRepository
{
    public RoleRepository(IdentityDbContext context) : base(context)
    {
    }

    public new IQueryable<Role> Get(Expression<Func<Role, bool>>? predicate = default, bool asNoTracking = false)
        => base.Get(predicate, asNoTracking);
}