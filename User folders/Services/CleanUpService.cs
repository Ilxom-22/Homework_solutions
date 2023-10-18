namespace User_folders.Services;

public class CleanUpService
{
    private readonly DirectoryService _directoryService;
    private readonly FileService _fileService;

    public CleanUpService(DirectoryService directoryService, FileService fileService)
    {
        _directoryService = directoryService;
        _fileService = fileService;
    }

    public void CleanUp()
    {
        var folders = _directoryService.GetUserFolders();

        foreach (var folder in folders)
        {
            var profileFiles = _directoryService.GetFiles(Path.Combine(folder, "Profile"));
            var resumeFiles = _directoryService.GetFiles(Path.Combine(folder, "Resume"));

            HandleProfileFolders(profileFiles);
            HandleResumeFolders(resumeFiles);
        }
    }

    private void HandleProfileFolders(IEnumerable<FileInfo> files)
    {
        foreach (var file in files)
        {
            if (file.Extension != ".jpg" && file.Extension != ".png" && file.Length / 1024 < 60)
                _fileService.DeleteFile(file.FullName);
        }
    }

    private void HandleResumeFolders(IEnumerable<FileInfo> files)
    {
        foreach (var file in files)
        {
            if (file.Extension != ".doc" && file.Extension != ".docx" && file.Extension != ".pdf")
                Console.WriteLine(file.FullName);
        }
    }
}