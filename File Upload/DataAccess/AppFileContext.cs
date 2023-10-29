using File_Upload.Models.Entities;
using FileBaseContext.Abstractions.Models.FileSet;
using FileBaseContext.Context.Models.Configurations;
using FileBaseContext.Context.Models.FileContext;

namespace File_Upload.DataAccess;

public class AppFileContext : FileContext, IDataContext
{
    public IFileSet<User, Guid> Users => Set<User, Guid>(nameof(Users));    

    public IFileSet<StorageFile, Guid> StorageFiles => Set<StorageFile, Guid>(nameof(StorageFiles));

    public AppFileContext(IFileContextOptions<AppFileContext> fileContextOptions) : base(fileContextOptions) { }
}