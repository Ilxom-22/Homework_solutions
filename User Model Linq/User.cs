namespace User_Model_Linq;

internal class User
{
    // Vazifa maqsadi Linq bo'lganligi sababli hech qanday validatsiya qo'shilmadi.
    public User(string name, string lastName, string email)
    {
        Name = name;
        LastName = lastName;
        EmailAddress = email;
    }

    public string Name { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
}

