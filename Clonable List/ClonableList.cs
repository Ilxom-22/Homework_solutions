namespace Clonable_List;

public class ClonableList<T> : List<T>, ICloneable where T : ICloneable
{
    public ClonableList<T> Clone()
    {
        var clone = new ClonableList<T>(); 

        foreach (var item in this)
            clone.Add((T)item.Clone());

        return clone;
    }

    object ICloneable.Clone()
    {
        return Clone();
    }
}
