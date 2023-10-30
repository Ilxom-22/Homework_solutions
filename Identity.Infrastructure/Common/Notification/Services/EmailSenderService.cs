using Identity.Application.Common.Notification.Services;
using Identity.Application.Common.Settings;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace Identity.Infrastructure.Common.Notification.Services;

public class EmailSenderService : IEmailSenderService
{
    private readonly EmailSenderSettings _senderSettings;

    public EmailSenderService(IOptions<EmailSenderSettings> senderSettings)
        => _senderSettings = senderSettings.Value;

    public async ValueTask<bool> SendEmailAsync(string emailAddress, string message)
    {
        var mail = new MailMessage(_senderSettings.CredentialAddress, emailAddress);
        mail.Subject = "Successful Registration";
        mail.Body = message;

        var client = new SmtpClient(_senderSettings.Host, _senderSettings.Port);
        client.Credentials = new NetworkCredential(_senderSettings.CredentialAddress, _senderSettings.Password);
        client.EnableSsl = true;

        await client.SendMailAsync(mail);

        return true;
    }
}