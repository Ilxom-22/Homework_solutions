namespace Filter_Model_Task.Models;

internal class UserCredentials
{
    public UserCredentials(Guid userId, string password)
    {
        UserId = userId;
        Password = password;
    }

    public Guid Id { get; set; }
    public string Password { get; set; }
    public Guid UserId { get; set; }
}

