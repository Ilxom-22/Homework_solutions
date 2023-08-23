var usernames = new List<string>()
{
    "CrystalPineapple87",
    "QuantumJester",
    "MidnightStarlight23",
    "ElectricWanderer",
    "SereneNebula42"
};

var tasks = new List<Task<FileStream?>>();
var newFolder = "Storage";
Directory.CreateDirectory(newFolder);


foreach (var username in usernames)
{
    tasks.Add(Task.Run(() =>
    {
        var path = Path.Combine(Directory.GetCurrentDirectory(), newFolder, $"{username.ToLower()}.txt");
        var stream = File.Create(path);
        Console.WriteLine($"File for {username} created!");
        return stream;
    }));

}

var result = await Task.WhenAll(tasks);

Console.WriteLine("All Tasks Done!");

