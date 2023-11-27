using EfCore.Interceptors.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCore.Interceptors.Persistence.EntityConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(user => user.FirstName).IsRequired().HasMaxLength(64);

        builder.HasData(
            new User
            {
                Id = Guid.Parse("4CBB0A46-7023-440F-8DF6-11BCAF59FBA6"),
                FirstName = "Admin",
                CreatedTime = DateTime.UtcNow,
            }
        );
    }
}