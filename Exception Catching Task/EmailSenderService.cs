

using System.Net.Mail;
using System.Net;

public class EmailSenderService : IEmailSenderService
{
    public async Task<bool> SendEmailAsync(string emailAddress)
    {
        var senderEmail = "sultonbek.rakhimov.recovery@gmail.com";
        var senderPassword = "szabguksrhwsbtie";

        var mail = new MailMessage(senderEmail, emailAddress);
        mail.Subject = "Successful Registration!";
        mail.Body = "We're thrilled to have you on board. Thanks for choosing us. Your journey with us begins now, and we're here to support you every step of the way.";

        try
        {
            var smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);
            smtpClient.EnableSsl = true;

            await smtpClient.SendMailAsync(mail);
            return true;
        }
        catch
        {
            return false;
        }
    }
}
