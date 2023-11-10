namespace IdentityDb.Application.Common.Notifications;

public interface IEmailSenderService
{
    ValueTask<bool> SendAsync(string email, string message);
}