List<WeatherReport> weatherReportList = new List<WeatherReport>
{
    new WeatherReport("California", 22.5),  
    new WeatherReport("New York", 20.0),    
    new WeatherReport("Texas", 26.8),       
    new WeatherReport("Florida", 31.4),     
    new WeatherReport("Illinois", 24.3),    
    new WeatherReport("Arizona", 32.3),     
    new WeatherReport("Colorado", 20.4),    
    new WeatherReport("Georgia", 27.9),     
    new WeatherReport("Ohio", 21.3),        
    new WeatherReport("Washington", 18.8)   
};

List<User> userList = new List<User>
{
    new User("John", "Doe"),
    new User("Alice", "Smith"),
    new User("Bob", "Johnson"),
    new User("Emily", "Brown"),
    new User("Michael", "Wilson"),
    new User("Sarah", "Johnson"),
    new User("David", "Miller"),
    new User("Linda", "Davis"),
    new User("James", "Clark"),
    new User("Jennifer", "Wilson")
};


var list = new List<IEntity>();
list.AddRange(weatherReportList);
list.AddRange(userList);

list
    .Where(self => self is WeatherReport weatherReport && weatherReport is { Degree: > 30 })
    .ToList()
    .ForEach(Console.WriteLine);

Console.WriteLine();

list
    .Where(self => self is User user && user is { FirstName: "John" })
    .ToList()
    .ForEach(Console.WriteLine);