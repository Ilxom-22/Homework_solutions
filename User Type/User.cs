namespace UserType;

public class User
{
    public string Name;
    public string LastName;
    public string Surname;

    public string _fullName => $"{Name} {LastName} {Surname}";


    public override int GetHashCode()
    {
        return _fullName.GetHashCode();
    }


    public override bool Equals(object? obj)
    {
        if (obj is User)
            return GetHashCode() == obj.GetHashCode();

        return false;
    }
}