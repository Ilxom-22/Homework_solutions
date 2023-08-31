
using Custom_type_and_members;

List<ShortenedLink> shortenedLinks = new List<ShortenedLink>
{
    new ShortenedLink("https://www.example.com/article123", "https://short.ly/abc123"),
    new ShortenedLink("https://www.example.net/page456", "https://short.ly/def456"),
    new ShortenedLink("https://www.sample.org/product789", "https://short.ly/ghi789"),
    new ShortenedLink("https://www.demo-site.com/video123", "https://short.ly/jkl123"),
    new ShortenedLink("https://www.test-site.org/blog987", "https://short.ly/mno987")
};

Console.WriteLine(shortenedLinks[0] == shortenedLinks[1]);
