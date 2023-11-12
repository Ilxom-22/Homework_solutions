using BlogSite.Application.Common.Foundations;
using BlogSite.Application.Common.ManagementServices;
using BlogSite.Domain.Constants;
using BlogSite.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogSite.Infrastructure.Common.ManagementServices;

public class BlogManagementService : IBlogManagementService
{
    private readonly IBlogService _blogService;

    private readonly ICommentService _commentService;

    private readonly IUserService _userService;

    public BlogManagementService(IBlogService blogService, ICommentService commentService, IUserService userService)
    {
        _blogService = blogService;
        _commentService = commentService;
        _userService = userService;
    }

    public async ValueTask<IList<Blog>> GetBlogsByAuthorId(Guid authorId, CancellationToken cancellationToken = default)
    {
        var blogs = _blogService.Get(blog => blog.AuthorId == authorId, true);

        return await blogs.ToListAsync(cancellationToken);
    }

    public async ValueTask<Comment> CreateCommentAsync(Comment comment, CancellationToken cancellationToken = default)
    {
        _ = await _blogService.GetByIdAsync(comment.BlogId, true, cancellationToken)
            ?? throw new InvalidOperationException("Blog not found!");

        return await _commentService.CreateAsync(comment, true, cancellationToken);
    }

    public async ValueTask<IList<Comment>> GetCommentsByBlogIdAsync(Guid blogId, CancellationToken cancellationToken = default)
    {
        var comments = _commentService.Get(comment => comment.BlogId == blogId, true);

        return await comments.ToListAsync(cancellationToken);
    }

    public async ValueTask<IList<User>> GetPopularBloggers(CancellationToken cancellationToken = default)
    {
        var bloggers = _userService.Get(user => user.Role.Type == RoleType.Author);
        var posts = _blogService.Get().Include(post => post.Commentaries);

        var query = from blogger in bloggers
                    join post in posts on blogger.Id equals post.AuthorId into bloggerPosts
                    select new
                    {
                        Blogger = blogger,
                        PostsCount = bloggerPosts.Count(post => post.Commentaries.Count >= 20)
                    }
                    into BlogPosts
                    where BlogPosts.PostsCount >= 5
                    select BlogPosts.Blogger;

        return await query.ToListAsync(cancellationToken);
    }
}