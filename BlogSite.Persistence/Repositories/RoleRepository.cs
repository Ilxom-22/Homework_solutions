using BlogSite.Domain.Entities;
using BlogSite.Persistence.DataContexts;
using BlogSite.Persistence.Repositories.Interfaces;

namespace BlogSite.Persistence.Repositories;

public class RoleRepository : EntityRepositoryBase<Role, AppDbContext>, IRoleRepository
{
    public RoleRepository(AppDbContext context) : base(context)
    {
    }
}