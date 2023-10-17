namespace Event_hadling.Models;

public class Email
{
    public Guid Id { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }

    public Email(string subject, string body)
    {
        Id = Guid.NewGuid();
        Subject = subject;
        Body = body;
    }
}