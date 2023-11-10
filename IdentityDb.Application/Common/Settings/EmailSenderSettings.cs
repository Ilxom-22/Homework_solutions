namespace IdentityDb.Application.Common.Settings;

public class EmailSenderSettings
{
    public string Host { get; set; } = default!;

    public int Port { get; set; } = default!;

    public string CredentialAddress { get; set; } = default!;

    public string Password { get; set; } = default!;
        
    public string SenderEmailAddress { get; set; } = default!;
}