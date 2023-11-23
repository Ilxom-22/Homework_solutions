using EfCore.Interceptors.Domain.Common.Entities;

namespace EfCore.Interceptors.Domain.Entities;

public class User : AuditableEntity, IModificationAuditableEntity, IDeletionAuditableEntity
{
    public string FirstName { get; set; } = default!;

    public Guid? DeletedByUserId { get; set; }

    public Guid? ModifiedByUserId { get; set; }
}