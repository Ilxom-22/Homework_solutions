List<Email> emailList = new List<Email>
{
    new Email("Welcome to Our System", "Hello {{FullName}},\n\nWelcome to our system. We're excited to have you as a member of our community.", "john.doe@example.com"),
    new Email("Account Deletion Notification", "Dear {{FullName}},\n\nWe are sorry to inform you that your account has been deleted from our system. This action was taken because [reason for account deletion].", "alice.smith@example.com"),
    new Email("Important Announcement", "Hello {{FullName}},\n\nWe have an important announcement to share with you. Please read the following message carefully...", "bob.johnson@example.com"),
    new Email("New Feature Announcement", "Hi {{FullName}},\n\nWe're thrilled to announce the release of a new feature in our system. This feature will enhance your experience.", "emily.brown@example.com"),
    new Email("Your Recent Activity", "Hello {{FullName}},\n\nHere is a summary of your recent activity on our platform. Please review the details below.", "michael.wilson@example.com")
};


var emailSenderService = new EmailSenderService();
var tasks = new List<Task>();

foreach (var email in emailList)
    tasks.Add(new Task(() => emailSenderService.SendEmailAsync(email).AsTask()));

Parallel.ForEach(tasks, task => task.Start());
await Task.WhenAll(tasks);