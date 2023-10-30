namespace Identity.Application.Common.Notification.Services;

public interface IEmailSenderService
{
    ValueTask<bool> SendEmailAsync(string emailAddress, string message);
}