using Filter_Model_Task.Models;
using System.Text.RegularExpressions;

namespace Filter_Model_Task.Services;

internal class UserCredentialsService: IUserCredentialsService
{
    private readonly List<UserCredentials> _userCredentials;

    public UserCredentialsService()
    {
        _userCredentials = new List<UserCredentials>();
    }

    public UserCredentials Add(Guid userId, string password)
    {
        if (!CheckPassword(password))
            throw new ArgumentException("Invalid Password!");

        var newCredential = new UserCredentials(userId, password);
        _userCredentials.Add(newCredential);
        return newCredential;
    }

    public UserCredentials? GetByUserId(Guid userId)
    {
        return _userCredentials.FirstOrDefault(user => user.UserId == userId);
    }

    private bool CheckPassword(string password)
    {
        bool hasUppercase = Regex.IsMatch(password, "[A-Z]");
        bool hasDigit = Regex.IsMatch(password, "\\d");
        bool isValidMinLength = password.Length >= 8;

        return hasUppercase && hasDigit && isValidMinLength;  
    }
}

