public interface IEmailSenderService
{
    Task<bool> SendEmailAsync(string emailAddress);
}