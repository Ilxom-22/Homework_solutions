using IdentityDb.Domain.Constants;
using IdentityDb.Domain.Entities;

namespace IdentityDb.Application.Common.Identity.Foundations;

public interface IRoleService
{
    ValueTask<Role?> GetByTypeAsync(RoleType type, bool asNoTracking = false, CancellationToken cancellationToken = default);
}