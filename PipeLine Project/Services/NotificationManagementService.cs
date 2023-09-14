using PipeLine_Project.Services.Inerfaces;

namespace PipeLine_Project.Services;

public class NotificationManagementService
{
    public readonly IUserService UserService;
    public readonly IEmailTemplateService EmailTemplateService;
    public readonly IEmailService EmailService;
    public readonly IEmailSenderService EmailSenderService;

    public NotificationManagementService(IUserService userService, IEmailTemplateService emailTemplateService, 
        IEmailService emailService, IEmailSenderService emailSenderService)
    {
        UserService = userService;
        EmailTemplateService = emailTemplateService;
        EmailService = emailService;
        EmailSenderService = emailSenderService;
    }

    public async Task NotifyUsers()
    {
        var users = UserService.GetUsers();
        var templates = EmailTemplateService.GetTemplates(users);
        var messages = EmailService.GetMessages(users, templates);
        await EmailSenderService.SendEmailsAsync(messages);
    }
}