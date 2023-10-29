using File_Upload.DataAccess;
using File_Upload.Models.Entities;

namespace File_Upload.Services.Foundations;

public class UserService
{
    private readonly IDataContext _context;

    public UserService(IDataContext context)
        => _context = context;

    public async ValueTask<User> CreateUserAsync(User user)
    {
        if (!IsValidUser(user))
            throw new ArgumentException("Invalid user!");

        if (!IsUnique(user))
            throw new ArgumentException("User already exists! Try to login!");

        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();  

        return user;    
    }

    public User GetUserByEmail(string email)
        => _context.Users.FirstOrDefault(user => user.Email == email)
            ?? throw new ArgumentException("User not found!");

    private bool IsValidUser(User user)
        => !string.IsNullOrWhiteSpace(user.Username) 
            && !string.IsNullOrWhiteSpace(user.FirstName) 
            && !string.IsNullOrWhiteSpace(user.LastName)
            && !string.IsNullOrWhiteSpace(user.Email) 
            && !string.IsNullOrWhiteSpace(user.PasswordHash);

    private bool IsUnique(User user)
        => !_context.Users.Any(self => self.Email == user.Email);
}