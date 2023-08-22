namespace Event_Stack;

public interface IEvent
{ 
    Guid Id { get; }
    string Name { get; set; }
    DateTime Date { get; set; }
}
