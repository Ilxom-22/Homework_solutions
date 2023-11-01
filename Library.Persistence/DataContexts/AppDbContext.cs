using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.Persistence.DataContexts;

public class AppDbContext : DbContext
{
    public DbSet<Book> Books => Set<Book>();

    public DbSet<Author> Authors => Set<Author>();


    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
}