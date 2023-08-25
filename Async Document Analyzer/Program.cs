
using Async_Document_Analyzer;

var path = @"D:\C# Homework\Homework_solutions\Async Document Analyzer\Texts Folder\text.txt";

var analyzer = new DocumentAnalyzer();
var results = new List<Task<int>>();

for (var i = 0; i < 10; i++)
    results.Add(analyzer.Rating(GetPath(i + 1)));

var ratings = await Task.WhenAll(results);

for (var i = 0; i < 10; i++)
    Console.WriteLine($"Rating for text {i+1}: {ratings[i]}");


string GetPath(int number)
{
    var directory = Path.GetDirectoryName(path);
    var fileName = Path.GetFileNameWithoutExtension(path);
    var fullFileName = fileName + Convert.ToString(number) + ".txt";
    return Path.Combine(directory, fullFileName);
}