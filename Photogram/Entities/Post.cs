using FileBaseContext.Abstractions.Models.Entity;

namespace Photogram.Entities;

public class Post : IFileSetEntity<Guid>
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string ImagePath { get; set; }
    public Guid AuthorId { get; set; }

    public Post(string title, string content, string imagePath, Guid authorId)
    {
        Id = Guid.NewGuid();
        Title = title;
        Content = content;
        ImagePath = imagePath;
        AuthorId = authorId;
    }
}