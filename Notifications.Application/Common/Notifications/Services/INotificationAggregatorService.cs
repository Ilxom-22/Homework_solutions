using Notifications.Application.Common.Notifications.Models;
using Notifications.Application.Common.Querying.Models;
using Notifications.Domain.Common.Exceptions;
using Notifications.Domain.Entities;

namespace Notifications.Application.Common.Notifications.Services;

public interface INotificationAggregatorService
{
    ValueTask<FuncResult<bool>> SendAsync(
        NotificationRequest notificationReques,
        CancellationToken cancellationToken = default
    );

    ValueTask<IList<NotificationTemplate>> GetTemplatesByFilterAsync(
        NotificationTemplateFilter notificationTemplateFilter,
        CancellationToken cancellationToken = default
    );
}