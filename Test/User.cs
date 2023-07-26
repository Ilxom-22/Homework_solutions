namespace Test;

public class User
{
    public int Id;
    public string Name;


    public User(int id, string name)
    {
        Id = id;
        Name = name;
    }



    public string Reverse()
    {
        return Name[..4];
    }

   
}