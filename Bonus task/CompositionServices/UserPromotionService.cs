using Bonus_task.Events;
using Bonus_task.Interfaces;
using Bonus_task.Models;

namespace Bonus_task.CompositionServices;

public class UserPromotionService
{
    private readonly BonusEventStore _bonusEventStore;
    private readonly IEnumerable<INotificationService> _notificationServices;

    public UserPromotionService(BonusEventStore bonusEventStore, IEnumerable<INotificationService> notificationServices)
    {
        _bonusEventStore = bonusEventStore;
        _notificationServices = notificationServices;

        _bonusEventStore.OnBonusAchieved += NotifyPromotedUser;
    }

    public async ValueTask NotifyPromotedUser(Bonus bonus)
    {
        foreach (var notification in _notificationServices)
            await notification.SendAsync(bonus.UserId, "Congratulations! You have been promoted!");
    }
}