using Notifications.Application.Common.Querying.Models;
using Notifications.Domain.Entities;
using System.Linq.Expressions;

namespace Notifications.Application.Common.Notifications.Services;

public interface IEmailTemplateService
{
    IQueryable<EmailTemplate> Get(
       Expression<Func<EmailTemplate, bool>>? predicate = default,
       bool asNoTracking = false
   );

    ValueTask<IList<EmailTemplate>> GetByFilterAsync(
        FilterPagination paginationOptions,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default
    );

    ValueTask<EmailTemplate> CreateAsync(
        EmailTemplate emailTemplate,
        bool saveChanges = true,
        CancellationToken cancellationToken = default
    );
}