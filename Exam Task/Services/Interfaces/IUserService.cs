using Exam_Task.Models;

namespace Exam_Task.Services.Interfaces;

public interface IUserService
{
    void Add(User user);
    void Update(User user);
    void Delete(long id);
    User Get(long id);
    IEnumerable<User> GetAll();
}
