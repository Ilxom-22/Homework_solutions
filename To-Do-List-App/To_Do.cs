namespace To_do;

public class ToDo
{
    public string TaskName;
    public bool IsDone;



    public ToDo(string taskName)
    {
        TaskName = taskName;
    }



    public override string ToString()
    {
        return $"{TaskName}";
    }
}