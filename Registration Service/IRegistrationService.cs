public interface IRegistrationService
{
    public void Register(string name, string lastName, string fatherName, string emailAddress, string username = "");
    public void Display();
}