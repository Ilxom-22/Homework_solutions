using File_Upload.Models.Entities;
using FileBaseContext.Abstractions.Models.FileSet;

namespace File_Upload.DataAccess;

public interface IDataContext
{
    IFileSet<User, Guid> Users { get; }
    IFileSet<StorageFile, Guid> StorageFiles { get; }

    ValueTask SaveChangesAsync();
}