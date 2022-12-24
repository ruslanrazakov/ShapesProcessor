using ShapesIntersection.Shapes;

public class CollisionObject
{
    public readonly Shape _colShape;

    public CollisionObject(Shape colShape)
    {
        _colShape = colShape;
    }

    public bool Intersects(CollisionObject other)
    {
        return _colShape.IntersectVisit(other._colShape);
    }
}