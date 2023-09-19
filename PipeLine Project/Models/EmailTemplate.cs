namespace PipeLine_Project.Models;

public class EmailTemplate
{
    public string Subject { get; set; }
    public string Body { get; set; }
    public Status ForStatus { get; set; }

    public EmailTemplate(string subject, string body, Status forStatus)
    {
        Subject = subject;
        Body = body;
        ForStatus = forStatus;
    }

    public override int GetHashCode()
        => HashCode.Combine(Subject, Body, ForStatus);
}