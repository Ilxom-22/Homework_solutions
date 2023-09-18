using System.Collections;

public class UserContainer : IEnumerable<User>
{
    private readonly List<User> _users;
    public UserContainer()
        => _users = new List<User>();
    
    public UserContainer(IEnumerable<User> userList)
        => _users = userList.ToList();
    
    public User this[int index] => _users[index];

    public User this[Guid id]
    {
        get
        {
            var user = _users.FirstOrDefault(self => self.Id == id);
            if (user == null)
                throw new ArgumentOutOfRangeException(nameof(user), "User with the given Id not found!");
            return user;
        }
    }

    public User this[string keyword]
    {
        get
        {
            var user = _users
                .FirstOrDefault(self => self.FirstName
                    .Equals(keyword, StringComparison.OrdinalIgnoreCase)
                        || self.LastName.Equals(keyword, StringComparison.OrdinalIgnoreCase)
                        || self.EmailAddress.Equals(keyword, StringComparison.OrdinalIgnoreCase));

            if (user == null)
                throw new ArgumentOutOfRangeException(nameof(user), "User with the given keyword not found!");
            return user;
        }
    }

    public IEnumerator<User> GetEnumerator()
        => _users.GetEnumerator();
        
    IEnumerator IEnumerable.GetEnumerator()
        => throw new NotImplementedException();
}