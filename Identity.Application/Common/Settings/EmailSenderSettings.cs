#pragma warning disable CS8618

namespace Identity.Application.Common.Settings;

public class EmailSenderSettings
{
    public string Host { get; set; }

    public int Port { get; set; }

    public string CredentialAddress { get; set; }

    public string Password { get; set; }

    public string SenderEmailAddress { get; set; }
}