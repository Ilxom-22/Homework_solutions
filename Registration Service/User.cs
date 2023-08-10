public class User
{
    public User(string name, string lastName, string fatherName, string emailAddress, string username)
    {
        Name = name;
        LastName = lastName;
        FatherName = fatherName;
        EmailAddress = emailAddress;
        Username = username;
    }



    public string Name { get; init; }
    public string LastName { get; init; }
    public string FatherName { get; init; }
    public string EmailAddress { get; set; }
    public string Username { get; set; }
    public bool IsActive { get; set; }



    public override string ToString()
    {
        string active = IsActive ? "active" : "inactive";
        return $"{Username} - {active}";
    }
}