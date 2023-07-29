namespace Shapes;

public class Triangle
{
    public Triangle(double a, double b, double c)
    {
        if (!ValidArgs(a, b, c))
            throw new ArgumentException("Not valid Triangle!");

        A = a;
        B = b;
        C = c;
    }

    public double A { get; private set; }
    public double B { get; private set; }
    public double C { get; private set; }

    public double Perimeter { get => A + B + C; }
    public double Area
    {
        get
        {
            var p = Perimeter / 2;
            return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
        }
    }



    private bool ValidArgs(double a, double b, double c)
    {
        return a < b + c && b < a + c && c < a + b;
    }
}