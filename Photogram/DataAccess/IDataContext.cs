using FileBaseContext.Abstractions.Models.FileSet;
using Photogram.Entities;

namespace Photogram.DataAccess;

public interface IDataContext
{
    IFileSet<User, Guid> Users { get; }
    IFileSet<Post, Guid> Posts { get; }
    ValueTask SaveChangesAsync();
}
