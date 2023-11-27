using EfCore.Interceptors.Application.Common.Identity.Models;

namespace EfCore.Interceptors.Application.Common.Identity.Services;

public interface IAuthService
{
    ValueTask<bool> SignUpAsync(UserDetails userDetails);

    string SignInAsync(UserDetails userDetails);    
}