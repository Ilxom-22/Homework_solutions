namespace HT_1;

internal class User
{
    public User(string email, string password, bool isAdmin = false)
    {
        Id =Guid.NewGuid();
        EmailAddress = email;
        Password = password;
        IsAdmin = isAdmin;
    }

    public Guid Id { get; set; }
    public string EmailAddress { get; set; }
    public string Password { get; set; }
    public bool IsAdmin { get; set; }

    public override string ToString()
    {
        var admin = IsAdmin ? "Admin" : "User";
        return $"{EmailAddress} - {Password} - {admin}";
    }
}
