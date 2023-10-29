using File_Upload.DataAccess;
using File_Upload.Models.Entities;

namespace File_Upload.Services.Foundations;

public class StorageFileService
{
    private readonly IDataContext _context;

    public StorageFileService(IDataContext context)
    {
        _context = context;
    }

    public async ValueTask<StorageFile> CreateAsync(StorageFile file)
    {
        if (!IsValidFile(file))
            throw new ArgumentException("Invalid file");

        if (!IsUnique(file))
            throw new ArgumentException("This file already exists!");

        await _context.StorageFiles.AddAsync(file);
        await _context.SaveChangesAsync();

        return file;
    }

    private bool IsUnique(StorageFile file)
        => !_context.StorageFiles.Any(self => self.UserId == file.UserId && self.Name == file.Name);

    private bool IsValidFile(StorageFile file)
        => !string.IsNullOrWhiteSpace(file.Name);
}