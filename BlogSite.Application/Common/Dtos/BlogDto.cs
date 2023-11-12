namespace BlogSite.Application.Common.Dtos;

public class BlogDto
{
    public Guid Id { get; set; }

    public string Title { get; set; } = default!;

    public string Content { get; set; } = default!;

    public DateTimeOffset PublishDate { get; set; }
}