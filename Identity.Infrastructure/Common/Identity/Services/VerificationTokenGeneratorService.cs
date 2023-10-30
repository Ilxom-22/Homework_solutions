using Identity.Domain.Enums;
using Identity.Domain.Entities;
using Identity.Application.Common.Identity.Services;
using Identity.Application.Common.Settings;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Identity.Infrastructure.Common.Identity.Services;

public class VerificationTokenGeneratorService : IVerificationCodeGeneratorService
{
    private readonly VerificationTokenSettings _verificationSettings;
    private readonly IDataProtector _protector;

    public VerificationTokenGeneratorService(IOptions<VerificationTokenSettings> verificationSettings, IDataProtectionProvider provider)
    {
        _verificationSettings = verificationSettings.Value;
        _protector = provider.CreateProtector(_verificationSettings.IdentityVerificationTokenPurpose);
    }

    public ValueTask<string> GenerateCode(VerificationType type, Guid userId)
    {
        var token = new VerificationCode
        {
            UserId = userId,
            Type = type,
            ExpiryTime = DateTimeOffset.UtcNow.AddMinutes(_verificationSettings.IdentityVerificationTokenExpiryTimeInMinutes)
        };

        return new(_protector.Protect(JsonConvert.SerializeObject(token)));
    }

    public (VerificationCode Code, bool IsValid) VerifyCode(string token)
    {
        if (string.IsNullOrWhiteSpace(token))
            throw new ArgumentException("Invalid verification token!");

        var unprotectedToken = _protector.Unprotect(token);

        var verificationToken = JsonConvert.DeserializeObject<VerificationCode>(unprotectedToken) 
            ?? throw new ArgumentException("Invalid verification token!");

        return (verificationToken, verificationToken.ExpiryTime > DateTimeOffset.UtcNow);
    }
}