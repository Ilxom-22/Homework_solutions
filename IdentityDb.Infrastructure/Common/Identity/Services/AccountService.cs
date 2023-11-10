using IdentityDb.Application.Common.Identity.Foundations;
using IdentityDb.Application.Common.Identity.Services;
using IdentityDb.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace IdentityDb.Infrastructure.Common.Identity.Services;

public class AccountService : IAccountService
{
    private readonly IUserService _userService;

    public AccountService(IUserService userService)
    {
        _userService = userService;
    }

    public async ValueTask<bool> CreateUserAsync(User user, CancellationToken cancellationToken = default)
    {
        await _userService.CreateAsync(user, cancellationToken: cancellationToken);

        return true;
    }

    public ValueTask<bool> VerificateAsync(string token, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async ValueTask<User?> GetUserByEmailAddress(string emailAddress) => 
        await _userService
        .Get(asNoTracking: true)
        .Include(user => user.Role)
        .SingleOrDefaultAsync(user => user.EmailAddress == emailAddress);
}