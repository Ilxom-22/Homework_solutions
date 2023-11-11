namespace BlogSite.Domain.Entities;

public class Comment
{
    public Guid Id { get; set; }

    public string Content { get; set; } = default!;

    public Guid AuthorId { get; set; }

    public Guid BlogId { get; set; }

    public virtual User Author { get; set; }    

    public virtual Blog Blog { get; set; }
}