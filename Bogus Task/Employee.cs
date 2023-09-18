public class Employee
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Department { get; set; }
    public int? ManagerId { get; set; }

    public override string ToString()
        => @$"ID: {Id} 
First name: {FirstName} 
Last name: {LastName} 
Department: {Department} 
Manager ID: {ManagerId}
";
}
