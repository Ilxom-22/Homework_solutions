public class UltimateClassroomAttendance : ClassroomAttendance
{
    public bool Mark(string fullName, bool isPresent, string cause = default)
    {
        if (!base.Mark(fullName, isPresent))
            return false;

        _students[fullName] += " " + cause;
        return true;
    }


    public override void Display()
    {
        base.Display();
        Console.WriteLine($"Percentage of present students - {GetStats()}%");
    }
}