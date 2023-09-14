using PipeLine_Project.Services.Inerfaces;
using System.Net.Mail;
using System.Net;
using PipeLine_Project.Models;

namespace PipeLine_Project.Services;

public class EmailSenderService : IEmailSenderService
{
    public async Task SendEmailsAsync(IEnumerable<EmailMessage> messages)
    {
        foreach (var message in messages)
        {
            var senderEmail = "sultonbek.rakhimov.recovery@gmail.com";
            var senderPassword = "szabguksrhwsbtie";

            var mail = new MailMessage(senderEmail, message.ReceiverAddress);
            mail.Subject = message.Subject;
            mail.Body = message.Body;

            var smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);
            smtpClient.EnableSsl = true;

            await smtpClient.SendMailAsync(mail);

            // To check if the emails are being sended.
            Console.WriteLine($"Email for user {message.ReceiverAddress} sent!");
        }
    }
}
