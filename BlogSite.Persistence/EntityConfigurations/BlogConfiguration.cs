using BlogSite.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogSite.Persistence.EntityConfigurations;

public class BlogConfiguration : IEntityTypeConfiguration<Blog>
{
    public void Configure(EntityTypeBuilder<Blog> builder)
    {
        builder.HasOne(blog => blog.Author).WithMany().HasForeignKey(blog => blog.AuthorId);
    }
}