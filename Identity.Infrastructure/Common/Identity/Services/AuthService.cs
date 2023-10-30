using Identity.Application.Common.Identity.Models;
using Identity.Application.Common.Identity.Services;
using Identity.Application.Common.Notification.Services;
using Identity.Domain.Entities;
using System.Security.Authentication;

namespace Identity.Infrastructure.Common.Identity.Services;

public class AuthService : IAuthService
{
    private readonly IPasswordHasherService _passwordHasherService;
    private readonly IEmailSenderService _emailSenderService;
    private readonly IAccountService _accountService;
    private readonly IAccessTokenGeneratorService _accessTokenGeneratorService;

    public AuthService(IPasswordHasherService passwordHasherService, IEmailSenderService emailSenderService, IAccountService accountService, IAccessTokenGeneratorService tokenGeneratorService)
    {
        _passwordHasherService = passwordHasherService;
        _emailSenderService = emailSenderService;
        _accountService = accountService;
        _accessTokenGeneratorService = tokenGeneratorService;
    }
         

    public async ValueTask<string> LoginAsync(LoginDetails loginDetails)
    {
        var user = await _accountService.GetUserByUsername(loginDetails.Username);

        if (!_passwordHasherService.VerifyPassword(loginDetails.Password, user.PasswordHash))
            throw new AuthenticationException();

        var accessToken = _accessTokenGeneratorService.GetToken(user);

        return accessToken;
    }

    public async ValueTask<bool> RegisterAsync(RegistrationDetails registrationDetails)
    {
        var user = new User
        {
            Id = Guid.NewGuid(),
            FirstName = registrationDetails.FirstName,
            LastName = registrationDetails.LastName,
            Username = registrationDetails.Username,
            EmailAddress = registrationDetails.EmailAddress,
            PasswordHash = _passwordHasherService.HashPassword(registrationDetails.Password),
            IsEmailAddressVerified = false
        };

        await _emailSenderService.SendEmailAsync(user.EmailAddress, "Welcome to the system!");

        await _accountService.CreateAsync(user);

        return true;
    }
}