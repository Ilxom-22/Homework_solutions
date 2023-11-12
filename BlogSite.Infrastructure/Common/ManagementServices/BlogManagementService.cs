using BlogSite.Application.Common.Foundations;
using BlogSite.Application.Common.ManagementServices;
using BlogSite.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogSite.Infrastructure.Common.ManagementServices;

public class BlogManagementService : IBlogManagementService
{
    private readonly IBlogService _blogService;

    private readonly ICommentService _commentService;

    public BlogManagementService(IBlogService blogService, ICommentService commentService)
    {
        _blogService = blogService;
        _commentService = commentService;
    }

    public async ValueTask<IList<Blog>> GetBlogsByAuthorId(Guid authorId, CancellationToken cancellationToken)
    {
        var blogs = _blogService.Get(blog => blog.AuthorId == authorId, true);

        return await blogs.ToListAsync(cancellationToken);
    }
}