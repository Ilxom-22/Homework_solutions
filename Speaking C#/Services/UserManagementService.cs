using Speaking_C_.Models;

namespace Speaking_C_.Services;

public class UsersManagementService
{
    private List<User> _userList = new()
    {
        new User("John", "Doe", false),
        new User("Jonibek", "Doniyorov", false),
        new User("Jane", "Doe", true),
        new User("Tommy", "Hilfiger", false),
        new User("Mark", "Polo", true),
    };

    public List<User> GetByCreatedDate(bool includeAdmin)
    {
        return _userList
                .Where(user => includeAdmin || user.IsAdmin == false)
                .OrderByDescending(user => user.CreatedDate)
                .ToList();
    }
}
