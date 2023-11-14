﻿using FluentValidation;
using Notifications.Domain.Entities;

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
    }
}