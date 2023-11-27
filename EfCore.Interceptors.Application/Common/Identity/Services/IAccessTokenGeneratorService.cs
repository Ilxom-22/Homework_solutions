using EfCore.Interceptors.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace EfCore.Interceptors.Application.Common.Identity.Services;

public interface IAccessTokenGeneratorService
{
    string GetToken(User user);

    JwtSecurityToken GetJwtToken(User user);

    List<Claim> GetUserClaims(User user);
}