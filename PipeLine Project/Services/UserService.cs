using PipeLine_Project.Models;
using PipeLine_Project.Services.Inerfaces;

namespace PipeLine_Project.Services;

public class UserService : IUserService
{
    private readonly List<User> _users;

    public UserService()
        =>  _users = new List<User>();
    
    public User Add(User user)
    {
        if (string.IsNullOrWhiteSpace(user.FirstName) || string.IsNullOrWhiteSpace(user.LastName))
            throw new ArgumentNullException();

        if (Exists(user))
            throw new ArgumentException("This user already exists!");

        _users.Add(user);
        return user;
    }

    public IEnumerable<User> GetUsers()
    {
        foreach (var user in _users)
            yield return user;
    }

    private bool Exists(User newUser)
        => _users.Any(user => user.Equals(newUser));
}