using EfCore.Interceptors.Domain.Common.Entities;
using EfCore.Interceptors.Domain.Constants;

namespace EfCore.Interceptors.Domain.Entities;

public class User : AuditableEntity, IModificationAuditableEntity, IDeletionAuditableEntity
{
    public string UserName { get; set; } = default!;

    public string Password { get; set; } = default!;

    public RoleType Role { get; set; }

    public Guid? DeletedByUserId { get; set; }

    public Guid? ModifiedByUserId { get; set; }
}