using Identity.Domain.Enums;
using Identity.Domain.Entities;

namespace Identity.Application.Common.Identity.Services;

public interface IVerificationCodeGeneratorService
{
    ValueTask<string> GenerateCode(VerificationType type, Guid userId);

    (VerificationCode Code, bool IsValid) VerifyCode(string code);
}