namespace ShapesIntersection;

public struct Circle : IShape
{
    public Vector Center { get; }
    public float Radius { get; }

    public Circle(Vector center, float radius)
    {
        Center = center;
        Radius = radius;
    }
}