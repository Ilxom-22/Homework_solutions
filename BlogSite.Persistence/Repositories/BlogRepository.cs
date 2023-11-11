using BlogSite.Domain.Entities;
using BlogSite.Persistence.DataContexts;
using BlogSite.Persistence.Repositories.Interfaces;

namespace BlogSite.Persistence.Repositories;

public class BlogRepository : EntityRepositoryBase<Blog, AppDbContext>, IBlogRepository
{
    public BlogRepository(AppDbContext context) : base(context)
    {  
    }
}