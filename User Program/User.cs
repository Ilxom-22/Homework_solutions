namespace UserProgram;

public class User
{
    public string firstName;
    public string lastName;
    public int age;

    public User(string firstName, string lastName, int age)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
    }



    public override string ToString()
    {
        return @$"First Name: {firstName}
Last Name: {lastName}
Age: {age}";
    }
}