using PipeLine_Project.Models;

namespace PipeLine_Project.Services.Inerfaces;

public interface IEmailSenderService
{
    Task SendEmailsAsync(IEnumerable<EmailMessage> messages);
}

