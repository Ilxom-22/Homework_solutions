using LearningCenter.Domain.Entities.Common.Enums;
using LearningCenter.Domain.Entities.Common.Location;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearningCenter.Persistence.EntityConfigurations;

public class LocationConfigurations : IEntityTypeConfiguration<LocationEntity>
{
    public void Configure(EntityTypeBuilder<LocationEntity> builder)
    {
        builder.HasOne(location => location.ParentLocation)
            .WithMany(location => location.ChildrenLocations)
            .HasForeignKey(location => location.ParentId);

        builder.HasData(new LocationEntity
        {
            Id = Guid.Parse("77589501-22b7-4fa2-9436-534c0c46913e"),
            Name = "Uzbekistan",
            Type = LocationType.Country,
        },
           new LocationEntity
           {
               Id = Guid.Parse("33517080-5e99-4591-b85d-2ed1ebf3bd98"),
               Name = "Tashkent",
               Type = LocationType.City,
               ParentId = Guid.Parse("77589501-22b7-4fa2-9436-534c0c46913e"),
           },
           new LocationEntity
           {
               Id = Guid.Parse("5eccba7f-4361-4ee6-832f-35ab309786cd"),
               Name = "Navoiy",
               Type = LocationType.City,
               ParentId = Guid.Parse("77589501-22b7-4fa2-9436-534c0c46913e"),
           });
    }
}