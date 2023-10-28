using Authorization.Api.Models.Entities;
using Authorization.Api.Models.Identity;
using System.Security.Authentication;

namespace Authorization.Api.Services;

public class AuthService
{
    private readonly TokenGeneratorService _tokenGeneratorService;
    private static readonly List<User> _users = new List<User>();

    public AuthService(TokenGeneratorService tokenGeneratorService)
        => _tokenGeneratorService = tokenGeneratorService;

    public ValueTask<bool> RegisterAsync(RegistrationDetails registrationDetails)
    {
        var user = new User
        {
            Id = Guid.NewGuid(),
            FirstName = registrationDetails.FirstName,
            LastName = registrationDetails.LastName,
            EmailAddress = registrationDetails.EmailAddress,
            Password = registrationDetails.Password,
            PhoneNumber = registrationDetails.PhoneNumber
        };

        _users.Add(user);

        return new ValueTask<bool>(true);
    }

    public ValueTask<string> LoginAsync(LoginDetails loginDetails)
    {
        var foundUser = _users.Find(user => user.EmailAddress == loginDetails.EmailAddress && user.Password == loginDetails.Password);

        if (foundUser == null)
            throw new AuthenticationException("Login details are invalid!");

        var accessToken = _tokenGeneratorService.GetToken(foundUser);

        return new ValueTask<string>(accessToken);
    }
}