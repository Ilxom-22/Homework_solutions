

using System.Net.Mail;
using System.Net;

public class EmailSenderService
{
    private object _locker = new object();
    private SmtpClient _smtpClient;

    public EmailSenderService()
        =>_smtpClient = new SmtpClient("smtp.gmail.com", 587);
    

    public ValueTask SendEmailAsync(Email email)
    {
        var senderEmail = "sultonbek.rakhimov.recovery@gmail.com";
        var senderPassword = "szabguksrhwsbtie";

        var mail = new MailMessage(senderEmail, email.ReceiverAddress);
        mail.Subject = email.Subject;
        mail.Body = email.Body;
        
        lock (_locker)
        {
            _smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);
            _smtpClient.EnableSsl = true;
            _smtpClient.SendMailAsync(mail).Wait();
        }
        return new ValueTask(Task.CompletedTask);
    }
}