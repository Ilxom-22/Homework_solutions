using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Notifications.Domain.Entities;
using Notifications.Domain.Enums;

namespace Notifications.Persistence.EntityConfigurations;

public class NotificationHistoryConfiguration : IEntityTypeConfiguration<NotificationHistory>
{
    public void Configure(EntityTypeBuilder<NotificationHistory> builder)
    {
        builder.Property(history => history.Content).IsRequired();

        builder.HasDiscriminator(notification => notification.NotificationType)
            .HasValue<SmsHistory>(NotificationType.Sms)
            .HasValue<EmailHistory>(NotificationType.Email);
    }
}