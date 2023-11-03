using LearningCenter.Domain.Entities.Common.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearningCenter.Persistence.EntityConfigurations;

public class UserSettingsConfigurations : IEntityTypeConfiguration<UserSettings>
{
    public void Configure(EntityTypeBuilder<UserSettings> builder)
    {
        builder.HasKey(x => x.UserId);

        builder.HasOne<User>().WithOne();
    }
}