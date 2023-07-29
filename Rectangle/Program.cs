namespace Shapes;

class Program
{
    static void Main(string[] args)
    {
        var triangle = new Triangle(3, 4, 5);
        Console.WriteLine($"Perimeter of triangle: {triangle.Perimeter}");
        Console.WriteLine($"Area of triangle: {triangle.Area}");
        Console.WriteLine();

        var a = new Point(0, 0);
        var b = new Point(0, 4);
        var c = new Point(3, 4);
        var d = new Point(4, 0);

        var rectangle = new Rectangle(a, b, c, d);

        Console.WriteLine($"Perimeter of rectangle: {rectangle.Perimeter}");
        Console.WriteLine($"Area of rectangle: {rectangle.Area}");

    }
}