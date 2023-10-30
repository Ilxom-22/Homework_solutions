using Identity.Domain.Enums;
using Identity.Domain.Entities;

namespace Identity.Application.Common.Identity.Services;

public interface IIdentityVerificationService
{
    ValueTask<string> GenerateVerificationCode(VerificationType type, Guid userId);

    (VerificationCode Code, bool IsValid) VerifyUser(string code);
}