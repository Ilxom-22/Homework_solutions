using Newtonsoft.Json;
using Video_linq;


List<Video> videoList = new List<Video>
{
    new Video("Introduction to Programming", "Learn the basics of programming.", 1200, 50, Topics.IT),
    new Video("Funny Cat Compilation", "Enjoy a collection of hilarious cat videos.", 3500, 200, Topics.Fun),
    new Video("Gaming Tips and Tricks", "Master the strategies for better gaming performance.", 800, 30, Topics.Gaming),
    new Video("Starting a Small Business", "Key steps to start your own small business.", 500, 15, Topics.Business),
    new Video("Debugging Techniques", "Effective methods to debug your code.", 600, 25, Topics.IT),
    new Video("Top 10 Strategy Games", "Explore the best strategy games of all time.", 1200, 80, Topics.Gaming),
    new Video("Stand-up Comedy Special", "Laugh out loud with this stand-up comedy show.", 2800, 150, Topics.Fun),
    new Video("Digital Marketing Strategies", "Boost your business with modern digital marketing.", 700, 40, Topics.Business),
    new Video("Data Structures Explained", "Understand the fundamentals of data structures.", 900, 30, Topics.IT),
    new Video("Economy Trends Analysis", "Analyzing current economic trends and forecasts.", 300, 10, Topics.Business)
};

var mostLike = videoList.MaxBy(video => video.Likes);
var leastDislike = videoList.MinBy(video => video.Dislikes);
var averageLikes = videoList.Average(video => video.Likes);
var sumDislike = videoList.Sum(video => video.Dislikes);
var videoProjection = videoList.Select(video => new {video.Title, video.Description}).ToList();
var uniqueTopics = videoList.DistinctBy(video => video.Topic).ToList();
var groupedByTopics = videoList.GroupBy(video => video.Topic);

Console.WriteLine($"Most Liked Video: {mostLike.Title} - {mostLike.Likes}");
Console.WriteLine($"Least Disliked Video: {leastDislike.Title} - {leastDislike.Dislikes}");
Console.WriteLine($"Average Likes: {averageLikes}");
Console.WriteLine($"All Dislikes: {sumDislike}");
Console.WriteLine();
Console.WriteLine("Title and Description Projection: ");
videoProjection.ForEach(video => Console.WriteLine($"{video.Title} - {video.Description}"));
Console.WriteLine();
uniqueTopics.ForEach(video => Console.WriteLine(video.Topic));
Console.WriteLine();

var data = JsonConvert.SerializeObject(groupedByTopics, Formatting.Indented);
Console.WriteLine(data);
