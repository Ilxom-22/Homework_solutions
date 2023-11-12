using BlogSite.Domain.Entities;

namespace BlogSite.Application.Common.ManagementServices;

public interface IBlogManagementService
{
    ValueTask<IList<Blog>> GetBlogsByAuthorId(Guid authorId, CancellationToken cancellationToken);
}