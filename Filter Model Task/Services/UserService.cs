using Filter_Model_Task.Models;

namespace Filter_Model_Task.Services;

internal class UserService : IUserService
{
    private readonly List<User> _users;

    public UserService()
    {
        _users = new List<User>();
    }

    public User Add(string firstname, string lastname, string emailAddress)
    {
        if (_users.Any(user => user.Email == emailAddress))
            throw new ArgumentException("This Email Address Already Exists!");

        var newUser = new User(firstname, lastname, emailAddress);
        _users.Add(newUser);
        return newUser;
    }

    public void Delete(Guid id)
    {
        var user = _users.FirstOrDefault(user => user.Id == id);
        if (user == null)
            throw new ArgumentException("User Not Found!");

        if (user.IsDeleted == true)
            throw new ArgumentException("User has already been deleted earlier!");

        user.IsDeleted = true;
    }

    public List<User> Filter(UserFilterModel userModel)
    {
        return _users.Where(user =>
            (userModel.FirstName is null || user.FirstName == userModel.FirstName)
            && (userModel.LastName is null || user.LastName == userModel.LastName))
            .Skip((userModel.PageToken - 1) * userModel.PageSize)
            .Take(userModel.PageSize).ToList(); ;
    }

    public List<User> Get(int pageSize, int pageToken)
    {
        return _users.Skip((pageToken - 1) * pageSize).Take(pageSize).ToList();
    }

    public List<User> Search(string searchKeyword, int pageSize, int pageToken)
    {
        return _users.Where(user =>
            user.FirstName.Contains(searchKeyword, StringComparison.OrdinalIgnoreCase)
            || user.LastName.Contains(searchKeyword, StringComparison.OrdinalIgnoreCase)
            || user.Email.Contains(searchKeyword, StringComparison.OrdinalIgnoreCase))
            .Skip((pageToken - 1) * pageSize)
            .Take(pageSize).ToList();
    }

    public User Update(User user, string email)
    {
        var updateUser = _users.FirstOrDefault(u => u.Id == user.Id);
        if (updateUser == null)
            throw new ArgumentException("User Not Found!");

        updateUser.Email = email;
        return updateUser;
    }
}

