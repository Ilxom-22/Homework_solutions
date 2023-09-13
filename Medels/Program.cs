var book = (Title: "", Author: "", Publicaton: DateTime.Now.AddYears(-5));


public record Person(string Name, int Age, string Address);

public struct Point
{
    public double X { get; set; }
    public double Y { get; set; }

    public Point(double x, double y)
    {
        X = x; 
        Y = y;
    }
}

public record Product(long Id, string Name, double Price);

public record Order(long Id, long CustomerId, List<Product> Product);

public record Customer(long Id, string Name, string Email, string PhoneNumber);

public record Address(long Id, string Street, string City, string State, string ZipCode);

public record Invoice(long Id, long CustomerId, double Amount);

public record Transaction(long Id, DateTime Date, double Amount);

public record Employee(long Id, string Name, string Department, double Salary);

public record Company(long Id, string Name, long AddressId, string PhoneNumber);

public record Vehicle(long Id, string Make, string Model, DateTime Year);

public record CustomerOrder(long Id, string CustomerName, string CustomerEmail, List<Order> OrderList);

public record AddressBookEntry(long Id, string Name, string Email, string PhoneNumber);

public struct Rectangle
{
    public double Height { get; set; }
    public double Width { get; set; }

    public Rectangle(double height, double width)
    {
        Height = height;
        Width = width;
    }
}

public struct Circle
{
    public double Radius { get; set; }
    public double CenterPoint { get; set; }

    public Circle(double radius, double centerPoint)
    {
        Radius = radius; 
        CenterPoint = centerPoint;
    }
}

public struct Line
{
    public double StartPoint { get; set; }
    public double EndPoint { get; set; }

    public Line(double start, double end)
    {
        StartPoint = start;
        EndPoint = end;
    }
}

public struct Triangle
{
    public double A { get; set; }
    public double B { get; set; }
    public double C { get; set; }

    public Triangle(double a, double b, double c)
    {
        A = a;
        B = b;
        C = c;
    }
}

public struct Color
{
    public int Red { get; set; }
    public int Green { get; set; }
    public int Blue { get; set; }

    public Color(int red, int green, int blue)
    {
        Red = red;
        Green = green;
        Blue = blue;
    }
}

public struct WeatherDate
{
    public double Temperature { get; set; }
    public double Humidity { get; set; }
    public double WindSpeed { get; set; }

    public WeatherDate(double temperature, double humidity, double windSpeed)
    {
        Temperature = temperature;
        Humidity = humidity;
        WindSpeed = windSpeed;
    }
}