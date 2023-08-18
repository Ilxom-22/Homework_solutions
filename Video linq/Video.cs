namespace Video_linq;

internal class Video
{
    public Video(string title, string description, int likes, int dislikes, Topics topic)
    {
        Title = title;
        Description = description;
        Likes = likes;
        Dislikes = dislikes;
        Topic = topic;
    }

    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int Likes { get; set; }
    public int Dislikes { get; set; }
    public Topics Topic { get; set; }

    public override string ToString()
    {
        return $"{Title}";
    }
}
