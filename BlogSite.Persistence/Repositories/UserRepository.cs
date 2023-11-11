using BlogSite.Domain.Entities;
using BlogSite.Persistence.DataContexts;
using BlogSite.Persistence.Repositories.Interfaces;

namespace BlogSite.Persistence.Repositories;

public class UserRepository : EntityRepositoryBase<User, AppDbContext>, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {
    }
}