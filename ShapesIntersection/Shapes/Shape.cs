namespace ShapesIntersection.Shapes;

public abstract class Shape
{
    public string Name {get; set;}
    public abstract bool IntersectVisit(Shape other);
    public abstract bool Intersect(Circle circle);
    public abstract bool Intersect(Polygon polygon);
}