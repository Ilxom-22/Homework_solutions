using Bonus_task.Models;

namespace Bonus_task.Events;

public class BonusEventStore
{
    public event Func<Bonus, ValueTask>? OnBonusAchieved;

    public async ValueTask CreateBonusAchievedEvent(Bonus bonus)
    {
        if (OnBonusAchieved != null)
            await OnBonusAchieved(bonus);
    }
}