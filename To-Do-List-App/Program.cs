namespace To_do;

class Program
{
    static void Main(string[] args)
    {
        var toDoList = new ToDoList();

        while (true)
        {
            Console.Write("Choose a command (Display all - d/ Mark Done - m/ Add - a/ Exit - e: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "d": 
                    toDoList.Display();
                    break;


                case "m":
                    if (!toDoList.Display())
                        break;

                    int taskNumber;
                    do
                    {
                        Console.Write("Choose task: ");
                    } while (!int.TryParse(Console.ReadLine(), out taskNumber));

                    var taskName = toDoList.MarkDone(taskNumber - 1);

                    if (taskName != null)
                        Console.WriteLine($"Task \"{taskName}\" marked as done!");
                    else
                        Console.WriteLine("Task Not Found!");
                    break;


                case "a":
                    string task = default;
                    while (true)
                    {
                        Console.Write("Input task name: ");
                        task = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(task) || task.Length < 4)
                            Console.WriteLine("Invalid Task Name. Please try again!");
                        else
                            break;
                    }

                    if (toDoList.AddTask(new ToDo(task.Trim())))
                        Console.WriteLine("Task Added Successfully!");
                    else
                        Console.WriteLine("This Task Already Exists!");
                    break;

                case "e":
                    return;
            }
        }

    }
}