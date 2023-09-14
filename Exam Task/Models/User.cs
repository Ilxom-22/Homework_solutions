namespace Exam_Task.Models;

public class User
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public User(long id, string firstName, string lastName)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
    }

    public override string ToString()
        => $"{Id} {FirstName} {LastName}";

    public override int GetHashCode()
        => HashCode.Combine(FirstName, LastName);

    public override bool Equals(object? obj)
    {
        if (obj == null) 
            return false;

        return GetHashCode() == obj.GetHashCode();
    }

}