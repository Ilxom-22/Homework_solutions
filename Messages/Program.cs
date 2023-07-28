namespace Messages;

class Program
{
    static void Main(string[] args)
    {
        var notification = new NotificationMessages();

        notification.AddMessage("SuccRegistration" , "You successfully registered");
        notification.AddMessage("AskPassword", "Enter your password");
        notification.AddMessage("Blocked", "Your account has been blocked");


        var searchedMessage = notification.SearchMessage("blocked");
        Console.WriteLine(searchedMessage == null ? "Not Found!" : searchedMessage);

        searchedMessage = notification.SearchMessage("Hello");
        Console.WriteLine(searchedMessage == null ? "Message Not Found!" : searchedMessage);
    }
}