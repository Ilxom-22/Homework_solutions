using Bonus_task.Events;
using Bonus_task.Interfaces;
using Bonus_task.Models;

namespace Bonus_task.CompositionServices;

public class UserBonusService
{
    private readonly IEntityBaseService<Bonus> _bonusService;
    private readonly BonusEventStore _bonusEventStore;
    private readonly OrderEventStore _orderEventStore;
    private readonly IEnumerable<INotificationService> _notificationService;

    public UserBonusService(IEntityBaseService<Bonus> bonusService, BonusEventStore bonusEventStore, OrderEventStore orderEventStore, IEnumerable<INotificationService> notificationService)
    {
        _bonusService = bonusService;
        _bonusEventStore = bonusEventStore;
        _notificationService = notificationService;
        _orderEventStore = orderEventStore;

        _orderEventStore.OnOrderCreated += RecalculateBonus;
    }

    public async ValueTask RecalculateBonus(Order order)
    {
        var userBonus = _bonusService.Get(bonus => bonus.UserId == order.UserId).First();

        userBonus.Amount += order.Amount;
        await _bonusService.UpdateAsync(userBonus);

        if (IsDigitCountIncreased(userBonus.Amount - order.Amount, userBonus.Amount))
            await _bonusEventStore.CreateBonusAchievedEvent(userBonus);
        else
        {
            foreach (var notification in _notificationService)
                await notification.SendAsync(order.UserId, $"There are {AmountLeftToGetBonus(userBonus.Amount)} to achieve bonus.");
        }
    }

    private bool IsDigitCountIncreased(double previousAmount, double newAmount)
        => CountDigit((int)Math.Round(previousAmount)) < CountDigit((int)Math.Round(newAmount));
    
    private int CountDigit(int number)
    {
        var count = 0;

        while (number > 0)
        {
            number /= 10;
            count++;
        }

        return count;
    }

    private int AmountLeftToGetBonus(double number)
    {
        var length = CountDigit((int)number);

        var nearestNumber = (int)Math.Pow(10, length);

        return nearestNumber - (int)number;
    }
}