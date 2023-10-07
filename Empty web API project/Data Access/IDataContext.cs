using Empty_web_API_project.Models;
using FileBaseContext.Abstractions.Models.FileSet;


namespace Empty_web_API_project.DataAccess;

public interface IDataContext
{
    IFileSet<User, Guid> Users { get; }
    IFileSet<Order, Guid> Orders { get; }
    ValueTask SaveChangesAsync();
}
