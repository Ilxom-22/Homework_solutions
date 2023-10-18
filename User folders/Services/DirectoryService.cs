using User_folders.Models;

namespace User_folders.Services;

public class DirectoryService
{
    private readonly string _path;

    public DirectoryService()
    {
        _path = Path.Combine(Directory.GetCurrentDirectory(), "Storage", "Users");
        InitializeRootDirectory();
    }

    public void CreateUserFolders(IEnumerable<User> users)
    {
        foreach (var user in users)
        {
            var directoryInfo = Directory.CreateDirectory(Path.Combine(_path, user.Id.ToString()));
            InitializeUserEssentialFolders(directoryInfo.FullName);
        }
    }

    public string GetUserFolderPath(User user)
    {
        var directories = Directory.GetDirectories(_path);

        return directories.First(dir => dir.EndsWith(user.Id.ToString()));
    }

    public IEnumerable<string> GetUserFolders()
        => Directory.GetDirectories(_path);

    public IEnumerable<FileInfo> GetFiles(string path)
    {
        var directoryInfo = new DirectoryInfo(path);

        return directoryInfo.EnumerateFiles();
    }

    private void InitializeRootDirectory()
    {
        Directory.CreateDirectory(_path);
    }

    private void InitializeUserEssentialFolders(string path)
    {
        Directory.CreateDirectory(Path.Combine(path, "Profile"));
        Directory.CreateDirectory(Path.Combine(path, "Resume"));
    }
}