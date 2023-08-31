namespace Auditable_Entity;

public class ChatMessage : AuditableEntity
{
    public ChatMessage(string subject, string message, int chatId)
    {
        Id = Guid.NewGuid();
        Subject = subject;
        Message = message;
        ChatId = chatId;
        CreatedDate = DateTime.Now;
    }


    public Guid Id { get; set; }
    public string Subject { get; set; }
    public string Message { get; set; }
    public int ChatId { get; set; }


    public override int GetHashCode()
    {
        int hash = 17;
        hash = hash * 23 + Subject.GetHashCode();
        hash = hash * 23 + Message.GetHashCode();
        hash = hash * 23 + ChatId.GetHashCode();
        return hash;
    }

    public override bool Equals(object? obj)
    {
        if (obj != null && obj is ChatMessage)
            return GetHashCode() == obj.GetHashCode();

        return false;
    }

    public override string ToString()
    {
        var time = LastModifiedDate == null ? CreatedDate : LastModifiedDate;
        return $"{Subject} - {Message} - {time}";
    }
}
