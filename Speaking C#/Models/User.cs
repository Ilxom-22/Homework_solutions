namespace Speaking_C_.Models;

public class User
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public bool IsAdmin { get; set; }

    public DateTime CreatedDate { get; set; }

    public User(string firstname, string lastname, bool admin)
    {
        Id = Guid.NewGuid();
        FirstName = firstname;
        LastName = lastname;
        IsAdmin = admin;
        CreatedDate = DateTime.Now;
    }

    public override string ToString()
    {
        return $"Id: {Id}, Firstname: {FirstName}, Lastname: {LastName}, Admin: {IsAdmin}, Created: {CreatedDate}";
    }
}
