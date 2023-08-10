using System.Collections;

public class CustomList<T> : IEnumerable
{
    private T[] _items;
    private long _lastIndex;

    public long Capacity { get; private set; }
    public long Count { get; private set; }

    public CustomList()
    {
        Capacity = 4;
        _items = new T[4];
        Count = 0;
        _lastIndex = 0;
    }

    public CustomList(int capacity)
    {
        if (capacity < 0)
            throw new ArgumentOutOfRangeException(nameof(capacity), "Non negative capacity required!");

        Capacity = capacity;
        _items = new T[capacity];
        Count = 0;
        _lastIndex = 0;
    }



    public void Add(T item)
    {
        EnsureCapacity();

        _items[_lastIndex++] = item;
        Count++;
    }

    public void AddRange(IEnumerable<T> items)
    {
        EnsureCapacity((uint)items.Count());

        foreach (var item in items)
        {
            _items[_lastIndex++] = item;
            Count++;
        }
    }

    public bool Contains(T item)
    {
        foreach (var i in _items)
            if (Equals(item, i))
                return true;

        return false;
    }

    public void CopyTo(T[] destinationArray)
    {
        if (destinationArray.Length < Count)
            throw new ArgumentException(
                "Destination array was not long enough. Check the destination index, length, and the array's lower bounds.");

        for (int i = 0; i < Count; i++)
            destinationArray[i] = _items[i];
    }

    public int IndexOf(T item)
    {
        for (int i = 0; i < Count; i++)
            if (Equals(item, _items[i]))
                return i;

        return -1;
    }

    public void Insert(int index, T item)
    {
        if (index < 0 || index > _lastIndex)
            throw new ArgumentOutOfRangeException(nameof(index), "Index must be within the bounds of the List!");

        EnsureCapacity();
        Count++;
        _lastIndex++;

        for (var i = _lastIndex; i >= 0; i--)
        {
            if (index == i)
            {
                _items[i] = item;
                break;
            }
            _items[i] = _items[i - 1];
        }
    }

    public void InsertRange(int index, IEnumerable<T> items)
    {
        if (index < 0 || index > _lastIndex)
            throw new ArgumentOutOfRangeException(nameof(index), "Index must be within the bounds of the List!");

        EnsureCapacity((uint)items.Count());
        Count += items.Count();
        _lastIndex = Count - 1;

        for (var i = _lastIndex; i >= index + items.Count(); i--)
            _items[i] = _items[i - items.Count()];
        
        foreach (var i in items)
            _items[index++] = i;
    }

    public void Remove(T item)
    {
        var index = IndexOf(item);
        if (index == -1)
            return;

        for (var i = index; i < Count; i++)
            _items[i] = _items[i + 1];

        Count--;
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index > _lastIndex)
            throw new ArgumentOutOfRangeException(nameof(index), "Index must be within the bounds of the List!");

        for (var i = index; i < Count; i++)
            _items[i] = _items[i + 1];

        Count--;
    }

    private void EnsureCapacity(uint additionalCapacity = 1)
    {
        if (_lastIndex + additionalCapacity < _items.Length) return;

        var newCapacity = GetNextSize((uint)_lastIndex + additionalCapacity);
        var newArray = new T[newCapacity];
        Array.Copy(_items, newArray, _items.Length);
        _items = newArray;
    }

    private uint GetNextSize(in uint desiredItemSize)
    {
        var newCapacity = desiredItemSize;
        do
        {
            newCapacity *= 2;
        } while (newCapacity < desiredItemSize);

        return newCapacity;
    }

    public IEnumerator GetEnumerator()
    {
        return _items[..(int)Count].GetEnumerator();
    }

    public T[] ToArray()
    {
        return _items[..(int)Count];
    }
}