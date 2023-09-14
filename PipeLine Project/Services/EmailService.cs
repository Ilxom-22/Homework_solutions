using PipeLine_Project.Services.Inerfaces;
using PipeLine_Project.Models;

namespace PipeLine_Project.Services;

public class EmailService : IEmailService
{
    public IEnumerable<EmailMessage> GetMessages(IEnumerable<User> users, IEnumerable<EmailTemplate> templates)
    {
        var rawData = users.Zip(templates, (user, template) => (user: user, template: template));

        foreach (var data in rawData)
        {
            var subject = data.template.Subject;
            var body = data.template.Body.Replace("{{FullName}}", data.user.FullName);
            var senderAddress = "samsung6771167@gmail.com";
            var receiverAddress = data.user.EmailAddress;

            yield return new EmailMessage(subject, body, senderAddress, receiverAddress);
        }
    }
}