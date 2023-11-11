using BlogSite.Domain.Common;

namespace BlogSite.Domain.Entities;

public class Blog : IEntity
{
    public Guid Id { get; set; }

    public string Title { get; set; } = default!;

    public string Content { get; set; } = default!;

    public DateTimeOffset PublishDate { get; set; }

    public DateTimeOffset? ModifiedDate { get; set; }

    public Guid AuthorId { get; set; }

    public virtual User Author { get; set; }
}