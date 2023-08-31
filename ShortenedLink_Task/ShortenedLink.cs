namespace Custom_type_and_members;

public class ShortenedLink
{
    public ShortenedLink(string url, string shortenedUrl)
    {
        Id = Guid.NewGuid();
        OriginalUrl = url;
        ShortenedUrl = shortenedUrl;
    }

    public Guid Id { get; set; }
    public string OriginalUrl { get; set; }
    public string ShortenedUrl { get; set; }


    public override int GetHashCode()
    {
        int hash = 17;
        hash = hash * 23 + Id.GetHashCode();
        hash = hash * 23 + OriginalUrl.GetHashCode();
        hash = hash * 23 + ShortenedUrl.GetHashCode();
        return hash;
    }

    public override bool Equals(object? obj)
    {
        if (obj is ShortenedLink)
            return GetHashCode() == obj.GetHashCode();

        return false;
    }
}
