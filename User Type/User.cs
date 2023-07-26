namespace UserType;

public class User
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Surname { get; set; }

    public string _fullName => $"{Name} {LastName} {Surname}";


    public override int GetHashCode()
    {
        return _fullName.GetHashCode();
    }


    public override bool Equals(object? obj)
    {
        if (obj is User)
            return this.GetHashCode() == obj.GetHashCode();

        return false;
    }
}