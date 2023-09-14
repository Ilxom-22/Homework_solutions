using PipeLine_Project.Models;
using PipeLine_Project.Services.Inerfaces;

namespace PipeLine_Project.Services;

public class EmailTemplateService : IEmailTemplateService
{
    private readonly List<EmailTemplate> _emailTemplates;

    public EmailTemplateService()
        => _emailTemplates = new List<EmailTemplate>();
    
    public EmailTemplate AddTemplate(EmailTemplate template)
    {
        if (string.IsNullOrWhiteSpace(template.Subject) || string.IsNullOrWhiteSpace(template.Body))
            throw new ArgumentNullException();

        if (Exists(template))
            throw new ArgumentException("This user already exists!");

        _emailTemplates.Add(template);
        return template;
    }

    public IEnumerable<EmailTemplate> GetTemplates(IEnumerable<User> users)
    {
        foreach (var user in users)
            yield return FindTemplateByStatus(user);
    }

    private EmailTemplate FindTemplateByStatus(User user)
    {
        var suitableTemplate = _emailTemplates
                .FirstOrDefault(template => template.ForStatus == user.Status);

        if (suitableTemplate == null)
            throw new ArgumentException("Suitable Email Template for the user doesn't exist!");

        return suitableTemplate;
    }

    private bool Exists(EmailTemplate newTemplate)
        => _emailTemplates.Any(template => template.Equals(newTemplate));
}