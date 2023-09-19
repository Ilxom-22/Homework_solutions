public class Account
{
    public string EmailAddress { get; set; }
    public string Password { get; set; }

    public Account(string emailAddress, string password)
    {
        EmailAddress = emailAddress;
        Password = password;
    }
}
