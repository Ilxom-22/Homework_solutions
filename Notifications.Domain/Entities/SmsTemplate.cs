using Notifications.Domain.Enums;

namespace Notifications.Domain.Entities;


public class SmsTemplate : NotificationTemplate
{
    public SmsTemplate()
    {
        NotificationType = NotificationType.Sms;
    }
}