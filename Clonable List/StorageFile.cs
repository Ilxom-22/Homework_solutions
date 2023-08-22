namespace Clonable_List;

public class StorageFile : ICloneable
{
    public StorageFile(string name, string description, int size)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        Size = size;
    }


    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Size { get; set; }


    public object Clone()
    {
        return new StorageFile(Name, Description, Size);
    }

    public override string ToString()
    {
        return $"{Name} - {Description} - {Size}";
    }
}
