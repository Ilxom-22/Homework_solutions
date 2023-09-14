namespace PipeLine_Project.Models;

public class User
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Status Status { get; set; }
    public string EmailAddress { get; set; }
    public string FullName => $"{FirstName} {LastName}";

    public User(string firstName, string lastName, Status status, string emailAddress)
    {
        FirstName = firstName;
        LastName = lastName;
        Status = status;
        EmailAddress = emailAddress;
    }

    public override int GetHashCode()
        => HashCode.Combine(FullName, EmailAddress);

    public override bool Equals(object? obj)
    {
        if (obj != null && obj is User)
            return GetHashCode() == obj.GetHashCode();

        return false;
    }
}