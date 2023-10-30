using Identity.Domain.Enums;
using Identity.Domain.Entities;
using Identity.Application.Common.Identity.Services;
using Identity.Application.Foundations;
using Identity.Application.Common.Settings;
using Microsoft.Extensions.Options;

namespace Identity.Infrastructure.Common.Identity.Services;

public class VerificationPasswordGeneratorService : IVerificationCodeGeneratorService
{
    private readonly IEntityBaseService<VerificationCode> _verificationCodeService;
    private readonly VerificationTokenSettings _verificationSettings;

    public VerificationPasswordGeneratorService(IEntityBaseService<VerificationCode> verificationCodeService, IOptions<VerificationTokenSettings> verificationSettings)
        => (_verificationCodeService, _verificationSettings) = (verificationCodeService, verificationSettings.Value);

    public async ValueTask<string> GenerateCode(VerificationType type, Guid userId)
    {
        var code = new VerificationCode
        {
            Id = Guid.NewGuid(),
            UserId = userId,
            Type = type,
            ExpiryTime = DateTime.UtcNow.AddMinutes(_verificationSettings.IdentityVerificationTokenExpiryTimeInMinutes),
            Code = new Random().Next(100000, 999999).ToString()
        };

        await _verificationCodeService.CreateAsync(code);

        return code.Code;
    }

    public (VerificationCode Code, bool IsValid) VerifyCode(string code)
    {
        if (string.IsNullOrWhiteSpace(code))
            throw new ArgumentException("Invalid Verificatin Code!");

        var foundCode = _verificationCodeService
            .Get(self => true)
            .FirstOrDefault(self => self.Code == code) 
            ?? throw new ArgumentException("Invalid Verification Code!");

        return (foundCode, foundCode.ExpiryTime > DateTimeOffset.UtcNow);
    }
}