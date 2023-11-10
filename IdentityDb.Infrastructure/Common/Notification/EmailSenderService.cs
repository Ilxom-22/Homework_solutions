using IdentityDb.Application.Common.Notifications;
using IdentityDb.Application.Common.Settings;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace IdentityDb.Infrastructure.Common.Notification;

public class EmailSenderService : IEmailSenderService
{
    private readonly EmailSenderSettings _emailSenderSettings;

    public EmailSenderService(IOptions<EmailSenderSettings> emailSenderSettings)
    {
        _emailSenderSettings = emailSenderSettings.Value;
    }

    public async ValueTask<bool> SendAsync(string email, string message)
    {
        var mail = new MailMessage(_emailSenderSettings.SenderEmailAddress, email);
        mail.Subject = "Welcome to the system!";
        mail.Body = message;

        var client = new SmtpClient(_emailSenderSettings.Host, _emailSenderSettings.Port);
        client.EnableSsl = true;
        client.Credentials = new NetworkCredential(_emailSenderSettings.CredentialAddress, _emailSenderSettings.Password);

        await client.SendMailAsync(mail);

        return true;
    }
}