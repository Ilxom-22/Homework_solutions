﻿using Notifications.Domain.Entities;
using System.Linq.Expressions;

namespace Notifications.Persistence.Repositories.Interfaces;

public interface IEmailTemplateRepository
{
    IQueryable<EmailTemplate> Get(
       Expression<Func<EmailTemplate, bool>>? predicate = default,
       bool asNoTracking = false
   );

    ValueTask<EmailTemplate> CreateAsync(
        EmailTemplate emailTemplate,
        bool saveChanges = true,
        CancellationToken cancellationToken = default
    );
}