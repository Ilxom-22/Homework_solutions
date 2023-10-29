using File_Upload.Models.Constants;
using File_Upload.Models.Entities;
using File_Upload.Models.Settings;
using Microsoft.Extensions.Options;

namespace File_Upload.Services.Foundations;

public class FileService
{
    private readonly FileSettings _fileSettings;

    public FileService(IOptions<FileSettings> fileSettings)
        => _fileSettings = fileSettings.Value;
    
    public bool Upload(Stream file, StorageFile storageFile)
    {
        var directoryPath = _fileSettings.FilePath
            .Replace(FilePathConstants.FileIdToken, storageFile.Id.ToString())
            .Replace(FilePathConstants.UserIdToken, storageFile.UserId.ToString());

        CreateDirectory(directoryPath);

        var filePath = Path.Combine(directoryPath, storageFile.Name);

        using var fileStream = new FileStream(filePath, FileMode.Create);

        file.CopyTo(fileStream);

        return true;
    }

    private void CreateDirectory(string directoryPath)
        => Directory.CreateDirectory(directoryPath);
}