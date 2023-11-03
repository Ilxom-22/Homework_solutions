using LearningCenter.Domain.Entities.Common.Identity;
using LearningCenter.Domain.Entities.Common.Location;
using LearningCenter.Domain.Entities.Courses;
using Microsoft.EntityFrameworkCore;

namespace LearningCenter.Persistence.DataContexts;

public class AppDbContext : DbContext
{
    public DbSet<User> Users => Set<User>();

    public DbSet<Course> Courses => Set<Course>();

    public DbSet<CourseStudent> CourseStudents => Set<CourseStudent>();

    public DbSet<UserSettings> UserSettings => Set<UserSettings>();

    public DbSet<UserRole> Roles => Set<UserRole>();

    public DbSet<LocationEntity> Locations => Set<LocationEntity>();


    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {      
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
}