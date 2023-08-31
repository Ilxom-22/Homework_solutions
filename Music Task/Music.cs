namespace Music_Task;

public class Music
{
    public Music(string name, string singerName)
    {
        Id = Guid.NewGuid();
        Name = name;
        SingerName = singerName;
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public string SingerName { get; set; }

    public override int GetHashCode()
    {
        int hash = 17;
        hash = hash * 23 + Name.GetHashCode();
        hash = hash * 23 + SingerName.GetHashCode();
        return hash;
    }

    public override bool Equals(object? obj)
    {
        if (obj != null && obj is Music)
            return GetHashCode() == obj.GetHashCode();

        return false;
    }

    public override string ToString()
    {
        return $"{Name} - {SingerName}";
    }
}

