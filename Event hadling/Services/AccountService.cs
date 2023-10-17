using Event_hadling.Models;

namespace Event_hadling.Services;

public class AccountService
{
    private readonly UserService _userService;
    private readonly UsersEventStore _usersEventStore;

    public AccountService(UserService userService, UsersEventStore userEvents)
    {
        _userService = userService;
        _usersEventStore = userEvents;
    }

    public async ValueTask<User> CreateUser(User user)
    {
        var newUser = _userService.CreateUser(user);
        
        await _usersEventStore.CreateUserAddedEvent(newUser);

        return newUser;
    }
}