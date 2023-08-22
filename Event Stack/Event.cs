namespace Event_Stack;

public class Event : IEvent
{
    public Event(string name, DateTime date)
    {
        Id = Guid.NewGuid();
        Name = name;
        Date = date;
    }


    public Guid Id { get; }
    public string Name { get; set; }
    public DateTime Date { get; set; }

    public override string ToString()
    {
        return $"{Name} - {Date}";
    }
}
