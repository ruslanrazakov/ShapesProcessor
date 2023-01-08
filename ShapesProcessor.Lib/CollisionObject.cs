using ShapesProcessor.Lib.Shapes;

public class CollisionObject
{
    public readonly Shape _shape;

    /// <summary>
    /// Wrapper for Shape to check collisions between shapes
    /// Uses Pattern Visitor for commutative intersections detection
    /// </summary>
    /// <param name="colShape"></param>
    public CollisionObject(Shape colShape)
    {
        _shape = colShape;
    }

    public bool Intersects(CollisionObject other)
    {
        return _shape.IntersectVisit(other._shape);
    }
}