using PipeLine_Project.Models;

namespace PipeLine_Project.Services.Inerfaces;

public interface IEmailService
{
    IEnumerable<EmailMessage> GetMessages(IEnumerable<User> users, IEnumerable<EmailTemplate> templates);
}

