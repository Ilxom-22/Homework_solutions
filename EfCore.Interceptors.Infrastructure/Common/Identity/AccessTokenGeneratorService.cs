using EfCore.Interceptors.Application.Common.Identity.Services;
using EfCore.Interceptors.Application.Common.Identity.Settings;
using EfCore.Interceptors.Domain.Constants;
using EfCore.Interceptors.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EfCore.Interceptors.Infrastructure.Common.Identity;

public class AccessTokenGeneratorService(IOptions<JwtSettings> jwtSettings) : IAccessTokenGeneratorService
{
    private readonly JwtSettings _jwtSettings = jwtSettings.Value;

    public string GetToken(User user)
        => new JwtSecurityTokenHandler().WriteToken(GetJwtToken(user));

    public JwtSecurityToken GetJwtToken(User user)
    {
        var claims = GetUserClaims(user);

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        return new JwtSecurityToken(
            issuer: _jwtSettings.ValidIssuer,
            audience: _jwtSettings.ValidAudience,
            claims: claims,
            notBefore: DateTime.UtcNow,
            expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiryTimeInMinutes),
            signingCredentials: credentials);
    }

    public List<Claim> GetUserClaims(User user)
        => new List<Claim>
        {
            new Claim(ClaimTypes.Role, user.Role.ToString()),
            new Claim(ClaimConstants.UserId, user.Id.ToString()),
            new Claim(ClaimConstants.UserName, user.UserName)
        };
}