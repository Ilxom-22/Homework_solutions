using Bogus;

var employeeFaker = new Faker<Employee>();
long id = 1;
employeeFaker
    .RuleFor(emp => emp.Id, faker => id++)
    .RuleFor(emp => emp.FirstName, faker => faker.Person.FirstName)
    .RuleFor(emp => emp.LastName, faker => faker.Person.LastName)
    .RuleFor(emp => emp.Department, faker => faker.PickRandom("HR", "Software Development", "Project Management"))
    .RuleFor(emp => emp.ManagerId, faker => faker.Random.Number(1, int.MaxValue));

var orderFaker = new Faker<Order>();
orderFaker
    .RuleFor(order => order.Id, Guid.NewGuid)
    .RuleFor(order => order.ProductName, faker => faker.Commerce.ProductName())
    .RuleFor(order => order.UserId, Guid.NewGuid);

var userAddressFaker = new Faker<UserAddress>();
userAddressFaker
    .RuleFor(address => address.Id, faker => id++)
    .RuleFor(address => address.Country, faker => faker.Address.Country())
    .RuleFor(address => address.State, faker => faker.Address.State())
    .RuleFor(address => address.Street, faker => faker.Address.StreetName())
    .RuleFor(address => address.ZipCode, faker => faker.Address.ZipCode())
    .RuleFor(address => address.UserId, faker => faker.Random.Number(1, int.MaxValue));

var blogPostFaker = new Faker<BlogPost>();
blogPostFaker
    .RuleFor(post => post.Id, Guid.NewGuid)
    .RuleFor(post => post.Title, faker => faker.Hacker.Phrase())
    .RuleFor(post => post.Content, faker => faker.Lorem.Sentence())
    .RuleFor(post => post.AuthorId, Guid.NewGuid);

var weatherReportFaker = new Faker<WeatherReport>();
weatherReportFaker
    .RuleFor(weather => weather.Id, Guid.NewGuid)
    .RuleFor(weather => weather.Location, faker => faker.Address.City())
    .RuleFor(weather => weather.Date, faker => faker.Date.Past())
    .RuleFor(weather => weather.TemperatureCelsius, faker => Math.Round(faker.Random.Double(0, 50), 1))
    .RuleFor(weather => weather.HumidityPercentage, faker => Math.Round(faker.Random.Double(0, 100), 1))
    .RuleFor(weather => weather.WindSpeedKmph, faker => Math.Round(faker.Random.Double(0, 50), 1))
    .RuleFor(weather => weather.WeatherDescription, faker =>
    {
        var weatherConditions = new[] { "Sunny", "Partly Cloudy", "Cloudy", "Rainy", "Snowy", "Foggy" };
        return faker.PickRandom(weatherConditions);
    });

// Employees data
Console.WriteLine("Employee Data: ");
employeeFaker.Generate(3).ForEach(Console.WriteLine);
Console.WriteLine();

// Orders Data
Console.WriteLine("Orders Data: ");
orderFaker.Generate(3).ForEach(Console.WriteLine);
Console.WriteLine();

// UserAddress Data
Console.WriteLine("User Address Data: ");
userAddressFaker.Generate(3).ForEach(Console.WriteLine);
Console.WriteLine();

// BlogPost Data
Console.WriteLine("Blog Post Data: ");
blogPostFaker.Generate(3).ForEach(Console.WriteLine);
Console.WriteLine();

// Weather Data
Console.WriteLine("Weather Forecast: ");
weatherReportFaker.Generate(3).ForEach(Console.WriteLine);
