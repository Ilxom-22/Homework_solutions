using Identity.Application.Common.Identity.Services;
using Identity.Application.Common.Settings;
using Identity.Domain.Entities;
using Identity.Domain.Enums;
using Microsoft.Extensions.Options;

namespace Identity.Infrastructure.Common.Identity.Services;

public class IdentityVerificationService : IIdentityVerificationService
{
    private readonly IEnumerable<IVerificationCodeGeneratorService> _verificationCodeGeneratorServices;
    private readonly VerificationTokenSettings _verificationSettings;

    public IdentityVerificationService(IEnumerable<IVerificationCodeGeneratorService> verificationCodeGeneratorServices, IOptionsSnapshot<VerificationTokenSettings> verificationSettings)
        => (_verificationCodeGeneratorServices, _verificationSettings) = (verificationCodeGeneratorServices, verificationSettings.Value);

    public async ValueTask<string> GenerateVerificationCode(VerificationType type, Guid userId)
    {
        var verificationService = GetVerificationService();

        var code = await verificationService.GenerateCode(type, userId);

        return code;
    }

    public (VerificationCode Code, bool IsValid) VerifyUser(string code)
    {
        var verificationService = GetVerificationService();

        return verificationService.VerifyCode(code);
    }

    private IVerificationCodeGeneratorService GetVerificationService()
        => _verificationCodeGeneratorServices
            .FirstOrDefault(service => service
                .GetType().Name
                    .Contains(_verificationSettings.VerificationServiceType))
            ?? throw new InvalidOperationException("Invalid verification service type specified in configuration.");
}