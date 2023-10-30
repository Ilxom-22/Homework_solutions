using FileBaseContext.Abstractions.Models.FileSet;
using FileBaseContext.Context.Models.Configurations;
using FileBaseContext.Context.Models.FileContext;
using Identity.Domain.Entities;

namespace Identity.Persistence.DataContext;

public class AppFileContext : FileContext, IDataContext
{
    public IFileSet<User, Guid> Users => Set<User, Guid>(nameof(Users));

    public AppFileContext(IFileContextOptions<AppFileContext> fileContextOptions) : base(fileContextOptions)
    {
    }
}