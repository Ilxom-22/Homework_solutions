using System.Text.RegularExpressions;

namespace HT_1;

internal class UserService
{
    private List<User> _users;

    public UserService(params User[] users)
    {
        _users = new List<User>();
        foreach (var user in users)
            AddUser(user);

        EnsureAdminExist();
    }

    public bool Add(string emailAddress, string password, bool isAdmin = false)
    {
        if (!CheckEmail(emailAddress) || !CheckPassword(password))
            return false;

        var user = new User(emailAddress, password, isAdmin);
        AddUser(user);
       
        return true;
    }

    private void AddUser(User user)
    {
        if (user.IsAdmin)
        {
            _users = _users.Prepend(user).ToList();
            return;
        }

        _users.Add(user);
        return;
    }

    public List<User> GetUsers()
        => _users;


    private void EnsureAdminExist()
    {
        if (!_users.Any(user => user.IsAdmin == true))
            AddUser(new User("default@gmail.com", "00000000", true));
    }

    private bool CheckEmail(string email)
    {
        var pattern = @"^[a-zA-Z]{4,}[a-zA-Z0-9]*(\.[a-zA-Z0-9]{4,})*@[a-zA-Z0-9]{4,}\.[a-zA-Z]{2,}[a-zA-Z]*$";
        return Regex.IsMatch(email, pattern);
    }

    private bool CheckPassword(string password)
    {
        var pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*#?&^_+\-=\[\]{}()|:;<>,.\?\/])[A-Za-z\d@$!%*#?&^_+\-=\[\]{}()|:;<>,.\?\/]{8,}$";
        return Regex.IsMatch(password, pattern);
    }
}
