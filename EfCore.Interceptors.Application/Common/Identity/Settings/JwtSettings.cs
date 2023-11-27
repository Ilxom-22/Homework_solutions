namespace EfCore.Interceptors.Application.Common.Identity.Settings;

public class JwtSettings
{
    public string SecretKey { get; set; }

    public string ValidIssuer { get; set; }

    public bool ValidateIssuer { get; set; }

    public bool ValidateIssuerSigningKey { get; set; }

    public string ValidAudience { get; set; }

    public bool ValidateAudience { get; set; }

    public bool ValidateLifetime { get; set; }

    public int ExpiryTimeInMinutes { get; set; }
}