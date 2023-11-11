using BlogSite.Application.Common.Foundations;
using BlogSite.Domain.Constants;
using BlogSite.Domain.Entities;
using BlogSite.Persistence.Repositories.Interfaces;
using System.Linq.Expressions;

namespace BlogSite.Infrastructure.Common.Foundations;

public class RoleService : IRoleService
{
    private readonly IRoleRepository _roleRepository;

    public RoleService(IRoleRepository roleRepository) => _roleRepository = roleRepository;

    public IQueryable<Role> Get(Expression<Func<Role, bool>>? predicate = default, bool asNoTracking = false) =>
        _roleRepository.Get(predicate, asNoTracking);

    public ValueTask<IList<Role>> GetAsync(IEnumerable<Guid> ids, bool asNoTracking = false, CancellationToken cancellationToken = default) =>
        _roleRepository.GetAsync(ids, asNoTracking, cancellationToken);

    public ValueTask<Role?> GetByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default) =>
        _roleRepository.GetByIdAsync(id, asNoTracking, cancellationToken);

    public ValueTask<Role?> GetByTypeAsync(RoleType type, bool asNoTracking = false, CancellationToken cancellationToken = default)
      => new(_roleRepository.Get(asNoTracking: asNoTracking).SingleOrDefault(role => role.Type == type));
}