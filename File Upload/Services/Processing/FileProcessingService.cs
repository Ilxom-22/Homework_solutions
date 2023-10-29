using File_Upload.Models.Entities;
using File_Upload.Services.Foundations;

namespace File_Upload.Services.Processing;

public class FileProcessingService
{
    private readonly FileService _fileService;
    private readonly StorageFileService _storageFileService;

    public FileProcessingService(FileService fileService, StorageFileService storageFileService)
    {
        _fileService = fileService;
        _storageFileService = storageFileService;
    }

    public async ValueTask<bool> UploadFileAsync(IFormFile file, Guid userId)
    {
        var storageFile = new StorageFile
        {
            Id = Guid.NewGuid(),
            Name = file.FileName,
            Extension = Path.GetExtension(file.Name),
            Size = file.Length,
            UserId = userId
        };

        await _storageFileService.CreateAsync(storageFile);

        _fileService.Upload(file.OpenReadStream(), storageFile);

        return true;   
    }
}