namespace Shapes;

public class Rectangle
{
    public Rectangle(Point a, Point b, Point c, Point d)
    {
        if (!IsValidRectangle(a, b, c, d))
            throw new ArgumentException("Not Valid Rectangle!");

        A = a;
        B = b;
        C = c;
        D = d;
    }


    public Point A { get; set; }
    public Point B { get; set; }
    public Point C { get; set; }
    public Point D { get; set; }

    private double AB { get => GetLength(A, B); }
    private double BC { get => GetLength(B, C); }
    private double CD { get => GetLength(C, D); }
    private double AD { get => GetLength(A, D); }


    public double Perimeter { get => AB + BC + CD + AD; }

    public double Area
    {
        get
        {
            var firstHalfArea = new Triangle(GetLength(A, C), GetLength(A, D), CD).Area;
            var secondHalfArea = new Triangle(AB, GetLength(A, D), GetLength(B, D)).Area;
            return firstHalfArea + secondHalfArea;
        }
    }


    private double GetLength(Point a, Point b)
    {
        return Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));
    }


    private bool IsValidRectangle(Point a, Point b, Point c, Point d)
    {
        if (a.Equals(b) || a.Equals(c) || a.Equals(d) || b.Equals(c) || b.Equals(d) || c.Equals(d)) return false;
        if ((a.X == b.X && b.X == c.X) || (b.X == c.X && c.X == d.X)) return false;
        if ((a.Y == b.Y && b.Y == c.Y) || (b.Y == c.Y && c.Y == d.Y)) return false;

        return true;
    }
}