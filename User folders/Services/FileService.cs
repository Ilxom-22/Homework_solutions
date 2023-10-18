using Bogus;

namespace User_folders.Services;

public class FileService
{
    public void CreateFilesForUser(string userFolderPath)
    {
        GenerateFile(Path.Combine(userFolderPath, "Resume"), "Resume");
        GenerateFile(Path.Combine(userFolderPath, "Profile"), "Profile");
    }

    public void DeleteFile(string filePath)
    {
        File.Delete(filePath);
    }

    private void GenerateFile(string path, string fileName)
    {
        var faker = new Faker();
        var random = new Random();

        var filePath = Path.Combine(path, fileName + faker.PickRandom(SeedData.SeedData.GetFileExtensions()));

        var fileStream = File.Create(filePath);

        var writer = new StreamWriter(fileStream);
        writer.WriteLine(faker.Lorem.Paragraphs(random.Next(1, 1000)));
        writer.Flush();
        writer.Close();
    }
}