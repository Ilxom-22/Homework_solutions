using Extension_Methods_Task;

var skillsA = new List<Skill>
 {
    new("Vue", SkillLevel.Beginner),
    new("Angular", SkillLevel.Experienced),
    new("React", SkillLevel.Master),
    new(".NET", SkillLevel.Expert),
    new("Python", SkillLevel.Experienced),
};

Console.WriteLine("Primary Skill Set: \n");
skillsA.ForEach(Console.WriteLine);
Console.WriteLine();


var updatedItemA = skillsA[2];
updatedItemA.Name = "CSS";
var updatedItemB = skillsA[3];
updatedItemB.Level = SkillLevel.Master;

var skillB = new List<Skill>
{
    new("Ruby", SkillLevel.Beginner),
    new("Swift", SkillLevel.Expert),
    updatedItemA,
    updatedItemB,
    skillsA[0],
    skillsA[3],
};

Console.WriteLine("Skills Update: \n");
skillB.ForEach(Console.WriteLine);
Console.WriteLine();


var result = skillsA.Update(skillB);
Console.WriteLine("Updated Skill Set: \n");
result.ForEach(Console.WriteLine);
