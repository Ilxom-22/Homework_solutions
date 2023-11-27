using EfCore.Interceptors.Domain.Common.Entities;

namespace EfCore.Interceptors.Domain.Entities;

public class Item : AuditableEntity, IModificationAuditableEntity, ICreationAuditableEntity, IDeletionAuditableEntity
{
    public string Name { get; set; } = default!;

    public Guid? ModifiedByUserId { get; set; }

    public Guid? CreatedByUserId { get; set; }

    public Guid? DeletedByUserId { get; set; }
}