using Identity.Domain.Enums;
using Identity.Application.Common.Identity.Services;
using Identity.Application.Common.Notification.Services;
using Identity.Application.Foundations;
using Identity.Domain.Entities;

namespace Identity.Infrastructure.Common.Identity.Services;

public class AccountService : IAccountService
{
    private readonly IEntityBaseService<User> _userService;
    private readonly IEmailSenderService _emailSenderService;
    private readonly IIdentityVerificationService _verificationService;

    public AccountService(IEntityBaseService<User> userService, IEmailSenderService emailSenderService, IIdentityVerificationService verificationService)
        => (_userService, _emailSenderService, _verificationService) = (userService, emailSenderService, verificationService);

    public async ValueTask<User> CreateAsync(User user)
    {
        var verificationToken = await _verificationService.GenerateVerificationCode(VerificationType.EmailAddressVerification, user.Id);
        await _emailSenderService.SendEmailAsync(user.EmailAddress, verificationToken);

        var createdUser = await _userService.CreateAsync(user);

        return createdUser;
    }

    public async ValueTask<bool> VerificateAsync(string token)
    {
        var verificationToken = _verificationService.VerifyUser(token);

        if (!verificationToken.IsValid)
            throw new ArgumentException("Invalid verification token!");

        var result = verificationToken.Code.Type switch
        {
            VerificationType.EmailAddressVerification => MarkEmailAsVerified(verificationToken.Code.UserId),
            _ => throw new InvalidOperationException("This method is not intended to accept other type of tokens!")
        };

        return await result;
    }

    public async ValueTask<bool> MarkEmailAsVerified(Guid userId)
    {
        var foundUser = await _userService.GetByIdAsync(userId);

        foundUser.IsEmailAddressVerified = true;

        await _userService.UpdateAsync(foundUser);

        return true;
    }

    public ValueTask<User> GetUserByUsername(string username)
    {
        var users = _userService.Get(user => true);

        var foundUser = users.Single(user => user.Username == username);

        return new(foundUser);
    }
}