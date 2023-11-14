using FluentValidation;
using Notifications.Domain.Entities;

namespace Notifications.Infrastructure.Common.Validators.NotificationTemplates;

public class NotificationTemplateValidator : AbstractValidator<NotificationTemplate>
{
    public NotificationTemplateValidator()
    {
        RuleFor(notification => notification.Content)
            .NotEmpty()
            .MinimumLength(5)
            .MaximumLength(500);
    }
}