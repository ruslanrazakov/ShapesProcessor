namespace ShapesIntersection;

public struct Circle : IShape
{
    public Point Center { get; }
    public double Radius { get; }

    public Circle(Point center, double radius)
    {
        Center = center;
        Radius = radius;
    }
}