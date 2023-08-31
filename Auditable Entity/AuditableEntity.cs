namespace Auditable_Entity;

public abstract class AuditableEntity
{
    protected DateTime CreatedDate { get; set; }
    protected DateTime? LastModifiedDate { get; set; }
}
