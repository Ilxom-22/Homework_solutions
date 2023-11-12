using BlogSite.Domain.Entities;
using BlogSite.Persistence.DataContexts;
using BlogSite.Persistence.Repositories.Interfaces;

namespace BlogSite.Persistence.Repositories;

public class CommentRepository : EntityRepositoryBase<Comment, AppDbContext>, ICommentRepository
{
    public CommentRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}