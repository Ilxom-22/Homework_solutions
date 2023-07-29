namespace Shapes;


public class Point
{
    public Point(double x, double y)
    {
        X = x;
        Y = y;
    }


    public double X { get; set; }
    public double Y { get; set; }


    public override int GetHashCode()
    {
        int hash = 17;
        hash = hash * 23 + X.GetHashCode();
        hash = hash * 23 + Y.GetHashCode();
        return hash;
    }


    public override bool Equals(object? obj)
    {
        if (obj != null && obj is Point)
            return GetHashCode() == obj.GetHashCode();

        return false;
    }
}