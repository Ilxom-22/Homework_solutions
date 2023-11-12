namespace BlogSite.Application.Common.Dtos;

public class CommentDto
{
    public Guid Id { get; set; }

    public string Content { get; set; } = default!;

    public Guid AuthorId { get; set; }

    public Guid BlogId { get; set; }

    public DateTimeOffset Date { get; set; }
}