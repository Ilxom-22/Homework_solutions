namespace Event_Stack;

public class EventStack<T> where T : IEvent
{
    private readonly List<T> _events;

    public EventStack()
    {
        _events = new List<T>();
    }

    public void Push(T newEvent)
    {
        if (_events.Count == 0)
            _events.Add(newEvent);

        if (_events[^1].Date > newEvent.Date)
            throw new ArgumentException("Invalid event!");

        _events.Add(newEvent);
    }

    public T Pop()
    {
        CheckStack();

        var lastItem = Peek();
        _events.RemoveAt(_events.Count - 1);

        return lastItem;
    }

    public T Peek()
    {
        CheckStack();
        return _events[^1];
    }

    private void CheckStack()
    {
        if (_events.Count == 0)
            throw new InvalidOperationException("Stack is empty.");
    }
}
