using Exam_Task.Models;
using Exam_Task.Services.Interfaces;

namespace Exam_Task.Services;

public class UserService : IUserService
{
    private readonly List<User> _users;

    public UserService()
    {
        _users = new List<User>();
    }

    public void Add(User user)
    {
        if (string.IsNullOrWhiteSpace(user.FirstName) || string.IsNullOrWhiteSpace(user.LastName))
            throw new ArgumentNullException();

        if (Exists(user))
            throw new ArgumentException("This user already exists!");

        _users.Add(user);
    }

    public void Delete(long id)
    {
        var user = Get(id);
        _users.Remove(user);
    }

    public User Get(long id)
    {
        var user = _users.FirstOrDefault(user => user.Id == id);
        if (user == null)
            throw new InvalidOperationException();

        return user;
    }

    public IEnumerable<User> GetAll()
        => _users;

    public void Update(User user)
    {
        var oldUser = Get(user.Id);
       
        oldUser.FirstName = user.FirstName;
        oldUser.LastName = user.LastName;
    }

    private bool Exists(User newUser)
        => _users.Any(user => user.Equals(newUser));
}