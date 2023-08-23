namespace Employee_Task;

public class Employee
{
    public Employee(string name, string lastName, string email)
    {
        Id = Guid.NewGuid();
        FirstName = name;
        LastName = lastName;
        Email = email;
    }

    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
}
