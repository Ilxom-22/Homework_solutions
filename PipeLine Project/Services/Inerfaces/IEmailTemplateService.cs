using PipeLine_Project.Models;

namespace PipeLine_Project.Services.Inerfaces;

public interface IEmailTemplateService
{
    IEnumerable<EmailTemplate> GetTemplates(IEnumerable<User> users);
    EmailTemplate AddTemplate(EmailTemplate template);
}