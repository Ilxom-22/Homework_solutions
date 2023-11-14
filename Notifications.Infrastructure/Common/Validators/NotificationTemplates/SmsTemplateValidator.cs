using FluentValidation;
using Notifications.Domain.Entities;

namespace Notifications.Infrastructure.Common.Validators.NotificationTemplates;

public class SmsTemplateValidator : AbstractValidator<SmsTemplate>
{
    public SmsTemplateValidator(IValidator<NotificationTemplate> baseValidator)
    {
        Include(baseValidator);
    }
}