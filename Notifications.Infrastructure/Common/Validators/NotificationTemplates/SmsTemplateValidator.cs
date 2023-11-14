using FluentValidation;
using Notifications.Domain.Entities;
using Notifications.Domain.Enums;

namespace Notifications.Infrastructure.Common.Validators.NotificationTemplates;

public class SmsTemplateValidator : AbstractValidator<SmsTemplate>
{
    public SmsTemplateValidator(IValidator<NotificationTemplate> baseValidator)
    {
        Include(baseValidator);

        RuleFor(sms => sms.NotificationType)
            .Equal(NotificationType.Sms);
    }
}