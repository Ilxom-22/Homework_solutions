#pragma warning disable CS8618

namespace Identity.Application.Common.Settings;

public class VerificationTokenSettings
{
    public string IdentityVerificationTokenPurpose { get; set; }


    public int IdentityVerificationTokenExpiryTimeInMinutes { get; set; }
}