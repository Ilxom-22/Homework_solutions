using Event_Stack;

var stack = new EventStack<Event>();

List<Event> events = new List<Event>
{
    new Event("Birthday Party", new DateTime(2023, 08, 25, 18, 0, 0)),
    new Event("Conference", new DateTime(2023, 09, 10, 9, 30, 0)),
    new Event("Anniversary", new DateTime(2023, 10, 15, 14, 0, 0)),
    new Event("Workshop", new DateTime(2023, 11, 5, 11, 0, 0)),
    new Event("Holiday Vacation", new DateTime(2023, 12, 20, 10, 0, 0)),
    new Event("Meeting", new DateTime(2024, 01, 8, 15, 45, 0)),
    new Event("Product Launch", new DateTime(2024, 02, 18, 16, 30, 0)),
    new Event("Family Reunion", new DateTime(2024, 03, 12, 12, 0, 0)),
    new Event("Seminar", new DateTime(2024, 04, 5, 13, 15, 0)),
    new Event("Music Concert", new DateTime(2024, 05, 22, 19, 0, 0))
};

for (var i = 0; i <= 5; i++)
    stack.Push(events[i]);

Console.WriteLine($"Removed event: {stack.Pop()}");
Console.WriteLine($"Last event: {stack.Peek()}");

for (var i = 6; i < 10; i++)
    stack.Push(events[i]);

Console.WriteLine("Added some events.");
Console.WriteLine($"Last event: {stack.Peek()}");
