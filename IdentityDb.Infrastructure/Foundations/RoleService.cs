using IdentityDb.Application.Common.Identity.Foundations;
using IdentityDb.Domain.Constants;
using IdentityDb.Domain.Entities;
using IdentityDb.Persistence.Repositories.Interfaces;

namespace IdentityDb.Infrastructure.Foundations;

public class RoleService : IRoleService
{
    private readonly IRoleRepository _roleRepository;

    public RoleService(IRoleRepository roleRepository) =>
        _roleRepository = roleRepository;

    public ValueTask<Role?> GetByTypeAsync(RoleType type, bool asNoTracking = false, CancellationToken cancellationToken = default)
        => new(_roleRepository.Get(asNoTracking: asNoTracking).SingleOrDefault(role => role.Type == type));
}