public class CrashReport : IReview
{
    public CrashReport(byte star, string message, string screenshot)
    {
        Id = Guid.NewGuid();
        Star = star;
        Message = message;
        Screenshot = screenshot;
    }



    private byte _star;
    private string _message;
    private string _screenshot;
    public Guid Id { get; set; }
    public byte Star { 
        get => _star; 
        set => _star = (value > 0 && value <= 5) 
            ? value 
            : throw new ArgumentOutOfRangeException(nameof(value), "Star can't be a negative number or more than 5!"); 
    }
    public string Message { 
        get => _message; 
        set => _message = (!string.IsNullOrWhiteSpace(value)) 
            ? value 
            : throw new ArgumentNullException(nameof(value), "Message can't be null!"); 
    }

    public string Screenshot { get; set; }
}
