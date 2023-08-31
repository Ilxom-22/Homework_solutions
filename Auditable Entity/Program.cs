
using Auditable_Entity;

List<ChatMessage> chatMessages = new List<ChatMessage>
{
    new ChatMessage("Greetings", "Hello there!", 1),
    new ChatMessage("Question", "Can you help me with this?", 1),
    new ChatMessage("Update", "Just wanted to let you know the event is postponed.", 2),
    new ChatMessage("Funny GIF", "Check out this hilarious GIF! 😄", 3),
    new ChatMessage("Feedback", "Your presentation was fantastic!", 4)
};

foreach (var i in chatMessages)
    Console.WriteLine(i);
