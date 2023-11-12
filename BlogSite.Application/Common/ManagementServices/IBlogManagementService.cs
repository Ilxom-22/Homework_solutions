using BlogSite.Domain.Entities;

namespace BlogSite.Application.Common.ManagementServices;

public interface IBlogManagementService
{
    ValueTask<IList<Blog>> GetBlogsByAuthorId(Guid authorId, CancellationToken cancellationToken = default);

    ValueTask<Comment> CreateCommentAsync(Comment comment, CancellationToken cancellationToken = default);

    ValueTask<IList<Comment>> GetCommentsByBlogIdAsync(Guid blogId, CancellationToken cancellationToken = default);

    ValueTask<IList<User>> GetPopularBloggers(CancellationToken cancellationToken = default);
}