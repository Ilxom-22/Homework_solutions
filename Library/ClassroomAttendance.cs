public class ClassroomAttendance
{
    protected readonly Dictionary<string, string> _students = new();



    public virtual void Display()
    {
        foreach (var student in _students)
            Console.WriteLine($"{student.Key} - {student.Value}");

        Console.WriteLine();
    }


    public bool Mark(string fullName, bool isPresent)
    {
        if (_students.ContainsKey(fullName))
            return false;

        _students[fullName] = isPresent ? "present" : "absent";
        return true;
    }



    internal protected int GetStats()
    {
        double presentStudentsCount = 0;

        foreach (var student in _students)
            if (student.Value.Contains("present"))
                presentStudentsCount++;

        return (int)((presentStudentsCount / _students.Count) * 100);
    }
}