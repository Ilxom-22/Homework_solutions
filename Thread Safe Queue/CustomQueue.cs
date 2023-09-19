public class CustomQueue<T>
{
    private readonly Queue<T> _items;
    private readonly object _locker = new object();

    public CustomQueue()
        => _items = new Queue<T>();

    public CustomQueue(IEnumerable<T> items) : this()
    {
        foreach (var item in items)
            _items.Enqueue(item);
    }

    public ValueTask EnqueueAsync(T item)
    {
        lock (_locker)
            _items.Enqueue(item);

        return ValueTask.CompletedTask;
    }

    public ValueTask<T> DequeueAnync()
    {
        T removedItem;
        lock (_locker)
        {
            removedItem = _items.Dequeue();
        }
        return new ValueTask<T>(removedItem);
    }
}