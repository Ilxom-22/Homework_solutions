using Event_hadling.Models;
using System.Net.Mail;
using System.Net;

namespace Event_hadling.Services;

public class EmailSenderService
{
    public async ValueTask SendEmailAsync(User user)
    {
        using (var smtp = new SmtpClient("smtp.gmail.com", 587))
        {
            smtp.Credentials = new NetworkCredential("sultonbek.rakhimov.recovery@gmail.com", "szabguksrhwsbtie");
            smtp.EnableSsl = true;

            var mail = new MailMessage("sultonbek.rakhimov.recovery@gmail.com", user.EmailAddress);
            mail.Subject = "Account activated!";
            mail.Body = "Registration process successfully ended!";

            await smtp.SendMailAsync(mail);
        }
    }
}