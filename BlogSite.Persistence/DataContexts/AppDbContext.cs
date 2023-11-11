using BlogSite.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogSite.Persistence.DataContexts;

public class AppDbContext : DbContext
{
    public DbSet<User> Users => Set<User>();

    public DbSet<Role> Roles => Set<Role>();

    public DbSet<Blog> Blogs => Set<Blog>();

    public DbSet<Comment> Comments => Set<Comment>();   


    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
}