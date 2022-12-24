using ShapesIntersection.Shapes;

public class CollisionObject
{
    public readonly Shape _shape;

    public CollisionObject(Shape colShape)
    {
        _shape = colShape;
    }

    public bool Intersects(CollisionObject other)
    {
        return _shape.IntersectVisit(other._shape);
    }
}