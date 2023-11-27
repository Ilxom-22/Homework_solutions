using EfCore.Interceptors.Application.Common.Identity.Models;
using EfCore.Interceptors.Application.Common.Identity.Services;
using EfCore.Interceptors.Domain.Constants;
using EfCore.Interceptors.Domain.Entities;
using System.Security.Authentication;

namespace EfCore.Interceptors.Infrastructure.Common.Identity;

public class AuthService(IUserService userService, IAccessTokenGeneratorService accessTokenGeneratorService) : IAuthService
{
    public async ValueTask<bool> SignUpAsync(UserDetails userDetails)
    {
        var newUser = new User
        {
            UserName = userDetails.UserName,
            Password = userDetails.Password,
            Role = RoleType.User,
        };

        await userService.CreateAsync(newUser);

        return true;
    }

    public string SignInAsync(UserDetails userDetails)
    {
        var foundUser = userService
            .Get(user => user.UserName == userDetails.UserName && user.Password == userDetails.Password).First();

        if (foundUser == null)
            throw new AuthenticationException("User not found!");

        return accessTokenGeneratorService.GetToken(foundUser);
    }  
}