using FluentValidation;
using Notifications.Domain.Entities;
using Notifications.Domain.Enums;

namespace Notifications.Infrastructure.Common.Validators.NotificationTemplates;

public class EmailTemplateValidator : AbstractValidator<EmailTemplate>
{
    public EmailTemplateValidator(IValidator<NotificationTemplate> baseValidator)
    {
        Include(baseValidator);

        RuleFor(email => email.Subject)
            .NotEmpty()
            .MinimumLength(4)
            .MaximumLength(128);

        RuleFor(email => email.NotificationType)
            .Equal(NotificationType.Email);
    }
}