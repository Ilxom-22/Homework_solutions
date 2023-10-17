using Event_hadling.Models;

namespace Event_hadling.Services;

public class UserService
{
    private readonly List<User> _users;

    public UserService()
    {
        _users = new List<User>();
    }

    public ICollection<User> GetAllUsers()
        => _users;

    public User CreateUser(User user)
    {
        _users.Add(user);

        return user;
    }
}