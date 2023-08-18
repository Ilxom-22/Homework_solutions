namespace Extension_Methods_Task;

public class Skill
{
    public Skill(string name, SkillLevel level)
    {
        Id = Guid.NewGuid();
        Name = name;
        Level = level;
    }


    public Guid Id { get; set; }
    public string Name { get; set; }
    public SkillLevel Level { get; set; }

    public override string ToString()
    {
        return $"{Name} - {Level}";
    }
}
