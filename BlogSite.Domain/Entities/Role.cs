using BlogSite.Domain.Constants;

namespace BlogSite.Domain.Entities;

public class Role
{
    public Guid Id { get; set; }

    public RoleType Type { get; set; }

    public bool IsRevoked { get; set; }

    public DateTimeOffset CreatedDate { get; set; }

    public DateTimeOffset? ModifiedDate { get; set; }
}