namespace Filter_Model_Task.Models;

internal class User
{
    public User(string firstName, string lastName, string email)
    {
        Id = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }

    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public bool IsDeleted { get; set; }


    public override string ToString()
    {
        return $"{FirstName} - {LastName} - {Email}";
    }
}

