namespace ShapesProcessor.Lib.Shapes;

public abstract class Shape
{
    public string? Guid {get; set;}
    public ShapeType? Figure {get; set;}
    public abstract bool IntersectVisit(Shape other);
    public abstract bool Intersect(Circle circle);
    public abstract bool Intersect(Polygon polygon);
}