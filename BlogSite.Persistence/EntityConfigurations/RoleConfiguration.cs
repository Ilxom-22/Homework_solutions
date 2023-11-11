using BlogSite.Domain.Constants;
using BlogSite.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogSite.Persistence.EntityConfigurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasIndex(role => role.Type).IsUnique();

        builder.HasData(new Role
        {
            Id = Guid.Parse("07AE0FB2-3609-4365-ABB9-38541E516326"),
            Type = RoleType.Reader,
            CreatedDate = DateTimeOffset.UtcNow,
        },

        new Role
        {
            Id = Guid.Parse("EB45FD2B-C31A-4AF1-9D2D-0BEF2B94F54A"),
            Type = RoleType.Author,
            CreatedDate = DateTimeOffset.UtcNow
        },
        
        new Role
        {
            Id = Guid.Parse("9601306C-A04D-4241-9D70-7F4F73868EEB"),
            Type = RoleType.Admin,
            CreatedDate = DateTimeOffset.UtcNow
        });
    }
}