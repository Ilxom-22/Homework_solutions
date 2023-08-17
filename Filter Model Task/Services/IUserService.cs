using Filter_Model_Task.Models;

namespace Filter_Model_Task.Services;

internal interface IUserService
{
    List<User> Get(int pageSize, int pageToken);
    List<User> Search(string searchKeyword, int pageSize, int pageToken);
    List<User> Filter(UserFilterModel userModel);
    User Add(string firstname, string lastname, string emailAddress);
    User Update(User user, string email);
    void Delete(Guid id);
}

