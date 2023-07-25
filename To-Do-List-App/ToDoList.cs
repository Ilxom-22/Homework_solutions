namespace To_do;

public class ToDoList
{
    public readonly List<ToDo> _toDoList = new List<ToDo>();
    private readonly List<ToDo> _doneTasks = new List<ToDo>();



    public bool Display()
    {
        if (_toDoList.Count == 0)
        {
            Console.WriteLine("The Tasks Inbox is empty!");
            return false;
        }

        for (int i = 0; i < _toDoList.Count; i++)
            Console.WriteLine($"{i+1}. {_toDoList[i]}");

        Console.WriteLine();
        return true;
    }



    public string Exists(int taskNumber)
    {
        if (_toDoList.Count > taskNumber)
            return _toDoList[taskNumber].ToString();

        return null;
    }



    public string MarkDone(int taskNumber)
    {
        string task = Exists(taskNumber);
        if (task != null)
        {
            _toDoList[taskNumber].IsDone = true;
            _doneTasks.Add(_toDoList[taskNumber]);
            _toDoList.RemoveAt(taskNumber);

            return task;
        }

        return null;
    }



    public bool AddTask(ToDo toDo)
    {
        foreach (var task in _toDoList)
            if (string.Equals(task.TaskName, toDo.TaskName, StringComparison.OrdinalIgnoreCase))
                return false;


        _toDoList.Add(toDo);
        return true;
    }
}