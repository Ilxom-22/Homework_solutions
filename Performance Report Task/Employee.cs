public class Employee
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool IsActive { get; set; }

    public Employee(string firstName, string lastName, bool isActive)
    {
        FirstName = firstName;
        LastName = lastName;
        IsActive = isActive;
    }

    public override int GetHashCode()
        => HashCode.Combine(FirstName, LastName, IsActive);

    public override bool Equals(object? obj)
    {
        if (obj != null && obj is Employee)
            return GetHashCode() == obj.GetHashCode();

        return false;
    }
}