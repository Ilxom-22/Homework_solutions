#pragma warning disable CS8618

using LearningCenter.Domain.Entities.Common.Enums;
using System.Text.Json.Serialization;

namespace LearningCenter.Domain.Entities.Common.Location;

public class LocationEntity
{
    public Guid Id { get; set; }

    public LocationType Type { get; set; }

    public string Name { get; set; }

    public Guid? ParentId { get; set; }

    public virtual ICollection<LocationEntity> ChildrenLocations { get; set; }

    [JsonIgnore]
    public virtual LocationEntity ParentLocation { get; set; }
}