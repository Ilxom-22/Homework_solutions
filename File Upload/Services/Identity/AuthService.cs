using File_Upload.Models.Entities;
using File_Upload.Models.Identity;
using File_Upload.Services.Foundations;
using System.Security.Authentication;

namespace File_Upload.Services.Identity;

public class AuthService
{
    private readonly TokenGeneratorService _tokenGeneratorService;
    private readonly PasswordHasherService _passwordHasherService;
    private readonly UserService _userService;

    public AuthService(TokenGeneratorService tokenGeneratorService, PasswordHasherService passwordHasherService, UserService userService)
    {
        _tokenGeneratorService = tokenGeneratorService;
        _passwordHasherService = passwordHasherService;
        _userService = userService;
    }

    public async ValueTask<User> RegisterAsync(RegisterDetails registrationDetails)
    {
        var user = new User
        {
            Id = Guid.NewGuid(),
            FirstName = registrationDetails.FirstName,
            LastName = registrationDetails.LastName,
            Email = registrationDetails.Email,
            PasswordHash = _passwordHasherService.HashPassword(registrationDetails.Password),
            Username = registrationDetails.Username
        };

        var createdUser = await _userService.CreateUserAsync(user);

        return createdUser;
    }

    public ValueTask<string> LoginAsync(LoginDetails loginDetails)
    {
        var foundUser = _userService.GetUserByEmail(loginDetails.Email);

        if (foundUser == null || !_passwordHasherService.VerifyPassword(loginDetails.Password, foundUser.PasswordHash))
            throw new AuthenticationException("Login details are invalid!");

        var accessToken = _tokenGeneratorService.GetToken(foundUser);

        return new(accessToken);
    }
}