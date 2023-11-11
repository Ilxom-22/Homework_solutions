using Microsoft.EntityFrameworkCore;

namespace BlogSite.Persistence.DataContexts;

public class AppDbContext : DbContext
{

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
}