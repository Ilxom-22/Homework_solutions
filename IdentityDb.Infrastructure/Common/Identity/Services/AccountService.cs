using IdentityDb.Application.Common.Identity.Foundations;
using IdentityDb.Application.Common.Identity.Services;
using IdentityDb.Application.Common.Notifications;
using IdentityDb.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace IdentityDb.Infrastructure.Common.Identity.Services;

public class AccountService : IAccountService
{
    private readonly IUserService _userService;
    private readonly IEmailSenderService _emailSenderService;

    public AccountService(IUserService userService, IEmailSenderService emailSenderService)
    {
        _userService = userService;
        _emailSenderService = emailSenderService;
    }

    public async ValueTask<bool> CreateUserAsync(User user, CancellationToken cancellationToken = default)
    {
        await _userService.CreateAsync(user, cancellationToken: cancellationToken);

        await _emailSenderService.SendAsync(user.EmailAddress, "Congratulations on successful registration!");

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