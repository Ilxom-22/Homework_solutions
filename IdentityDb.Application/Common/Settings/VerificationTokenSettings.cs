namespace IdentityDb.Application.Common.Settings;

public class VerificationTokenSettings
{
    public string IdentityVerificationTokenPurpose { get; set; } = default!;

    public string IdentityVerificationExpirationDurationInMinutes { get; set; } = default!;
}