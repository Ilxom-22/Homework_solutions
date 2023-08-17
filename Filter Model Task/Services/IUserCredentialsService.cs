using Filter_Model_Task.Models;

namespace Filter_Model_Task.Services;

internal interface IUserCredentialsService
{
    UserCredentials? GetByUserId(Guid userId);
    UserCredentials Add(Guid userId, string password);
}

