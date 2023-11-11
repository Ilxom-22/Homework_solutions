using BlogSite.Application.Common.Foundations;
using BlogSite.Domain.Entities;
using BlogSite.Persistence.Repositories.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace BlogSite.Infrastructure.Common.Foundations;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository) => 
        _userRepository = userRepository;

    public IQueryable<User> Get(Expression<Func<User, bool>>? predicate = default, bool asNoTracking = false) =>
        _userRepository.Get(predicate, asNoTracking);

    public ValueTask<IList<User>> GetAsync(IEnumerable<Guid> ids, bool asNoTracking = false, CancellationToken cancellationToken = default) =>
        _userRepository.GetAsync(ids, asNoTracking, cancellationToken);

    public ValueTask<User?> GetByIdAsync(Guid userId, bool asNoTracking = false, CancellationToken cancellationToken = default) =>
        _userRepository.GetByIdAsync(userId, asNoTracking, cancellationToken);

    public async ValueTask<User> CreateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        if (!IsValidUser(user))
            throw new ValidationException("Invalid user.");
        
        return await _userRepository.CreateAsync(user, saveChanges, cancellationToken);
    }

    public async ValueTask<User> UpdateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        if (!IsValidUser(user))
            throw new ValidationException("Invalid user.");

        var foundUser = await _userRepository.GetByIdAsync(user.Id, cancellationToken: cancellationToken)
            ?? throw new InvalidOperationException("User not found!");

        foundUser.FirstName = user.FirstName;
        foundUser.LastName = user.LastName;
        foundUser.IsEmailAddressVerified = user.IsEmailAddressVerified;
        foundUser.PasswordHash = user.PasswordHash;

        return await _userRepository.UpdateAsync(foundUser, saveChanges, cancellationToken);
    }

    public ValueTask<User> DeleteAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default) =>
        _userRepository.DeleteAsync(user, saveChanges, cancellationToken);

    public ValueTask<User> DeleteByIdAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default) =>
        _userRepository.DeleteByIdAsync(id, saveChanges, cancellationToken);

    private static bool IsValidUser(User user) =>
       !(string.IsNullOrWhiteSpace(user.FirstName)
       || string.IsNullOrWhiteSpace(user.LastName)
       || string.IsNullOrWhiteSpace(user.EmailAddress)
       || string.IsNullOrWhiteSpace(user.PasswordHash));
}