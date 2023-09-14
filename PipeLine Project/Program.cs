using PipeLine_Project.Services;
using PipeLine_Project.Models;

var userService = new UserService();
var emailTemplateService = new EmailTemplateService();
var emailService = new EmailService();
var emailSenderService = new EmailSenderService();
var notificationService = new NotificationManagementService(userService, emailTemplateService,
    emailService, emailSenderService);

List<User> userList = new List<User>
{
    new User("John", "Doe", Status.Registered, "john.doe@example.com"),
    new User("Alice", "Smith", Status.Active, "alice.smith@example.com"),
    new User("Bob", "Johnson", Status.Registered, "bob.johnson@example.com"),
    new User("Emily", "Brown", Status.Active, "emily.brown@example.com"),
    new User("Michael", "Wilson", Status.Deleted, "ilxomkarimjonov22@gmail.com")
};

List<EmailTemplate> emailTemplates = new List<EmailTemplate>()
{
    new ("Registered User", "Hi {{FullName}}, welcome to our system!", Status.Registered),
    new ("Deleted User", "Dear {{FullName}}, We are sorry to inform you that your account has been deleted from our system.", Status.Deleted),
    new ("Active User", "Hello {{FullName}}, We're pleased to have you as an active member of our system. Thank you for being a part of our community. If you have any questions or need assistance, feel free to reach out to our support team.", Status.Active)
};

foreach (var user in userList)
    userService.Add(user);

foreach (var  emailTemplate in emailTemplates)
    emailTemplateService.AddTemplate(emailTemplate);

await notificationService.NotifyUsers();