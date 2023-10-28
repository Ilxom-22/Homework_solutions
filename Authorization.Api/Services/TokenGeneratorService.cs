using Authorization.Api.Models.Constants;
using Authorization.Api.Models.Entities;
using Authorization.Api.Models.Settings;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Authorization.Api.Services;

public class TokenGeneratorService
{
    private readonly JwtSettings _jwtSettings;

    public TokenGeneratorService(IOptions<JwtSettings> jwtSettings)
        => _jwtSettings = jwtSettings.Value;

    public string GetToken(User user)
    {
        var token = GetJwtSecurityToken(user);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public JwtSecurityToken GetJwtSecurityToken(User user)
    {
        var claims = GetClaims(user);

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        return new JwtSecurityToken(
            issuer: _jwtSettings.ValidIssuer,
            audience: _jwtSettings.ValidAudience,
            claims: claims,
            notBefore: DateTime.Now,
            expires: DateTime.Now.AddDays(_jwtSettings.ExpirationTimeInMinutes),
            signingCredentials: credentials
            );
    }

    public List<Claim> GetClaims(User user)
    {
        return new List<Claim>
        {
            new(ClaimTypes.Email, user.EmailAddress),
            new(ClaimConstants.UserId, user.Id.ToString())
        };
    }
}