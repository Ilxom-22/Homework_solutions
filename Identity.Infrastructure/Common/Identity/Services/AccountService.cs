using Identity.Application.Common.Enums;
using Identity.Application.Common.Identity.Services;
using Identity.Application.Common.Notification.Services;
using Identity.Application.Foundations;
using Identity.Domain.Entities;

namespace Identity.Infrastructure.Common.Identity.Services;

public class AccountService : IAccountService
{
    private readonly IEntityBaseService<User> _userService;
    private readonly IEmailSenderService _emailSenderService;
    private readonly IVerificationTokenGeneratorService _verificationTokenGeneratorService;

    public AccountService(IEntityBaseService<User> userService, IEmailSenderService emailSenderService, IVerificationTokenGeneratorService verificationTokenGeneratorService)
        => (_userService, _emailSenderService, _verificationTokenGeneratorService) = (userService, emailSenderService, verificationTokenGeneratorService);

    public async ValueTask<User> CreateAsync(User user)
    {
        var verificationToken = _verificationTokenGeneratorService.GenerateToken(VerificationType.EmailAddressVerification, user.Id);
        await _emailSenderService.SendEmailAsync(user.EmailAddress, verificationToken);

        var createdUser = await _userService.CreateAsync(user);

        return createdUser;
    }

    public async ValueTask<bool> VerificateAsync(string token)
    {
        var verificationToken = _verificationTokenGeneratorService.DecodeToken(token);

        if (!verificationToken.IsValid)
            throw new ArgumentException("Invalid verification token!");

        var result = verificationToken.Token.Type switch
        {
            VerificationType.EmailAddressVerification => MarkEmailAsVerified(verificationToken.Token.UserId),
            _ => throw new InvalidOperationException("This method is not intended to accept other type of tokens!")
        };

        return await result;
    }

    public async ValueTask<bool> MarkEmailAsVerified(Guid userId)
    {
        var foundUser = await _userService.GetByIdAsync(userId);

        foundUser.IsEmailAddressVerified = true;

        return true;
    }

    public ValueTask<User> GetUserByUsername(string username)
    {
        var users = _userService.Get(user => true);

        var foundUser = users.Single(user => user.Username == username);

        return new(foundUser);
    }
}