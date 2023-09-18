public class User
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; } 
    public string EmailAddress { get; set; }

    public User(string firsName, string lastName, string emailAddress)
    {
        Id = Guid.NewGuid();
        FirstName = firsName;
        LastName = lastName;
        EmailAddress = emailAddress;
    }

    public override string ToString()
        => $"{Id} {FirstName} {LastName} {EmailAddress}";
}