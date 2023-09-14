using PipeLine_Project.Models;

namespace PipeLine_Project.Services.Inerfaces;

public interface IUserService
{
    User Add(User user);
    IEnumerable<User> GetUsers();
}