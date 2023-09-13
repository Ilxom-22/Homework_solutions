var manager = new Manager("Mike", "Nickson", 1, "HR", 2000);
var employee = new Employee("Nick", "Johnson", 2, "HR", 1, 1000);

Console.WriteLine(manager);
Console.WriteLine(employee);


public abstract record Person(string FirstName, string LastName);

public record Manager(string FirstName, string LastName, long Id, string Department, double Salary) : Person(FirstName, LastName);

public record Employee(string FirstName, string LastName, long Id, string Department, long ManagerId, double Salary) : Person(FirstName, LastName);