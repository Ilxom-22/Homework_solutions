namespace EfCore.Interceptors.Domain.Common.Entities;

public class SoftDeletedEntity : Entity, ISoftDeletedEntity
{
    public bool IsDeleted { get; set; }

    public DateTimeOffset? DeletedTime { get; set; }
}