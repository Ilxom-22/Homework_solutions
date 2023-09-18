List<User> userList = new List<User>
{
    new User("John", "Doe", "john.doe@example.com"),
    new User("Alice", "Smith", "alice.smith@example.com"),
    new User("Bob", "Johnson", "bob.johnson@example.com"),
    new User("Emily", "Brown", "emily.brown@example.com"),
    new User("Michael", "Wilson", "michael.wilson@example.com"),
    new User("Sarah", "Johnson", "sarah.johnson@example.com"),
    new User("David", "Miller", "david.miller@example.com"),
    new User("Linda", "Davis", "linda.davis@example.com"),
    new User("James", "Clark", "james.clark@example.com"),
    new User("Jennifer", "Wilson", "jennifer.wilson@example.com")
};

var container = new UserContainer(userList);

Console.WriteLine(container[2]);

var id = userList[9].Id;
Console.WriteLine(container[id]);
Console.WriteLine(container["emily"]);
Console.WriteLine();
container.Where(user => user.FirstName.Contains("j", StringComparison.OrdinalIgnoreCase)).ToList().ForEach(Console.WriteLine);