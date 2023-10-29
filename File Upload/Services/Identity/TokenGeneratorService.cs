using File_Upload.Models.Constants;
using File_Upload.Models.Entities;
using File_Upload.Models.Settings;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace File_Upload.Services.Identity;

public class TokenGeneratorService
{
    private readonly JwtSettings _jwtSettings;

    public TokenGeneratorService(IOptions<JwtSettings> jwtSettings)
        => _jwtSettings = jwtSettings.Value;

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

        return new JwtSecurityToken(
            issuer: _jwtSettings.ValidIssuer,
            audience: _jwtSettings.ValidAudience,
            claims: claims,
            notBefore: DateTime.Now,
            expires: DateTime.Now.AddDays(_jwtSettings.ExpirationTimeInMinutes),
            signingCredentials: credentials);
    }

    public List<Claim> GetClaims(User user)
    {
        return new List<Claim>
        {
            new(ClaimTypes.Email, user.Email),
            new(ClaimConstants.UserId, user.Id.ToString())
        };
    }
}