using FileBaseContext.Abstractions.Models.FileSet;
using First.Api.Models;

namespace First.Api.DataAccess;

public interface IDataContext
{
    IFileSet<User, Guid> Users { get; }
    IFileSet<Order, Guid> Orders { get; }
    ValueTask SaveChangesAsync();
}
