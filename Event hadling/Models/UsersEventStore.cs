namespace Event_hadling.Models;

public class UsersEventStore
{
    public event Func<User, ValueTask>? OnUserAdded;

    public async ValueTask CreateUserAddedEvent(User user)
    {
        if (OnUserAdded != null)
            await OnUserAdded(user);
    }
}