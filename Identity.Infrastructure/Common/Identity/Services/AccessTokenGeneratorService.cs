using Identity.Application.Common.Constants;
using Identity.Application.Common.Identity.Services;
using Identity.Application.Common.Settings;
using Identity.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Identity.Infrastructure.Common.Identity.Services;

public class AccessTokenGeneratorService : IAccessTokenGeneratorService
{
    private readonly JwtSettings _jwtSettings;

    public AccessTokenGeneratorService(IOptions<JwtSettings> settings)
        => _jwtSettings = settings.Value;

    public string GetToken(User user)
    {
        var jwtToken = GetJwtToken(user);

        var token = new JwtSecurityTokenHandler().WriteToken(jwtToken);

        return token;   
    }

    public JwtSecurityToken GetJwtToken(User user)
    {
        var claims = GetClaims(user);

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var jwtToken = new JwtSecurityToken
        (
            issuer: _jwtSettings.ValidIssuer,
            audience: _jwtSettings.ValidAudience,
            claims: claims,
            notBefore: DateTime.UtcNow,
            expires: DateTime.UtcNow.AddDays(_jwtSettings.ExpiryTimeInMinutes),
            signingCredentials: credentials
        );

        return jwtToken;
    }

    public List<Claim> GetClaims(User user)
        => new List<Claim>
        {
            new(ClaimTypes.Email, user.EmailAddress),
            new(ClaimConstants.UserId, user.Id.ToString()),
            new(ClaimConstants.Username, user.Username)
        };
}