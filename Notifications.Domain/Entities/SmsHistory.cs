using Notifications.Domain.Enums;

namespace Notifications.Domain.Entities;

public class SmsHistory : NotificationHistory
{
    public SmsHistory()
    {
        NotificationType = NotificationType.Sms;
    }
}