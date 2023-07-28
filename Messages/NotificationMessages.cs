namespace Messages;

public class NotificationMessages
{
    private readonly Dictionary<string, string> messages = new();



    protected KeyValuePair<string, string>? FindMessage(string message)
    {
        foreach (var pair in messages)
            if (pair.Key.Contains(message, StringComparison.OrdinalIgnoreCase))
                return pair;

        return null;
    }



    public string? SearchMessage(string message)
    {
        var output = FindMessage(message);

        return output == null ? null : output.Value.Value;
    }



    public bool AddMessage(string messageName, string content)
    {
        if (messages.ContainsKey(messageName))
            return false;

        messages[messageName] = content;
        return true;
    }
}