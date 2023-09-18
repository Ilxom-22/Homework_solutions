public class BlogPost
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public Guid AuthorId { get; set; }

    public override string ToString()
        => @$"ID: {Id} 
Title: {Title} 
Content: {Content} 
Author ID: {AuthorId}
";
}
