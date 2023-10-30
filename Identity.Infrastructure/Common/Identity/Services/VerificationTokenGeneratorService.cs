using Identity.Application.Common.Enums;
using Identity.Application.Common.Identity.Models;
using Identity.Application.Common.Identity.Services;
using Identity.Application.Common.Settings;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Identity.Infrastructure.Common.Identity.Services;

public class VerificationTokenGeneratorService : IVerificationTokenGeneratorService
{
    private readonly VerificationTokenSettings _verificationSettings;
    private readonly IDataProtector _protector;

    public VerificationTokenGeneratorService(IOptions<VerificationTokenSettings> verificationSettings, IDataProtectionProvider provider)
    {
        _verificationSettings = verificationSettings.Value;
        _protector = provider.CreateProtector(_verificationSettings.IdentityVerificationTokenPurpose);
    }

    public string GenerateToken(VerificationType type, Guid userId)
    {
        var token = new VerificationToken
        {
            UserId = userId,
            Type = type,
            ExpiryTime = DateTimeOffset.UtcNow.AddMinutes(_verificationSettings.IdentityVerificationTokenExpiryTimeInMinutes)
        };

        return _protector.Protect(JsonConvert.SerializeObject(token));
    }

    public (VerificationToken Token, bool IsValid) DecodeToken(string token)
    {
        if (string.IsNullOrWhiteSpace(token))
            throw new ArgumentException("Invalid verification token!");

        var unprotectedToken = _protector.Unprotect(token);

        var verificationToken = JsonConvert.DeserializeObject<VerificationToken>(unprotectedToken) 
            ?? throw new ArgumentException("Invalid verification token!");

        return (verificationToken, verificationToken.ExpiryTime > DateTimeOffset.UtcNow);
    }
}