using BlogSite.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogSite.Persistence.EntityConfigurations;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.HasOne(comment => comment.Author).WithMany().HasForeignKey(comment => comment.AuthorId);
        builder.HasOne(comment => comment.Blog).WithMany().HasForeignKey(comment => comment.BlogId);
    }
}