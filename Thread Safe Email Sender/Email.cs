

public class Email
{
    public string Subject { get; set; }
    public string Body { get; set; }
    public string ReceiverAddress { get; set; }

    public Email(string subject, string body, string receiverAddress)
    {
        Subject = subject; 
        Body = body; 
        ReceiverAddress = receiverAddress;
    }
}