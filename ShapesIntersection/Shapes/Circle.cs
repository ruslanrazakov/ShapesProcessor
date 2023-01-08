namespace ShapesProcessor.Lib.Shapes;

public class Circle : Shape
{
    public Vector Center { get; }
    public float Radius { get; }

    public Circle(Vector center, float radius)
    {
        Center = center;
        Radius = radius;
    }

    public override bool IntersectVisit(Shape other)
    {
        return other.Intersect(this);
    }

    public override bool Intersect(Circle other)
    {
        Vector dv = other.Center - this.Center;
        return dv.X * dv.X + dv.Y * dv.Y <= MathF.Pow(this.Radius + other.Radius, 2);
    }

    public override bool Intersect(Polygon polygon)
    {
        var normals = new List<Vector>();

        foreach (var edge in polygon.Edges)
        {
            normals.Add(edge.Normalize());
        }

        normals.Add(MathHelpers.Polygons.GetPolygonCircleAxis(polygon, this));
        foreach (Vector axis in normals)
        {
            float min1 = 0; float min2 = 0; float max1 = 0; float max2 = 0;
            MathHelpers.Polygons.ProjectPolygon(axis, polygon, ref min1, ref max1);
            MathHelpers.Polygons.ProjectPolygon(axis, this, ref min2, ref max2);
            float intervalDistance = min1 < min2 ? min2 - max1 : min1 - max2;
            if (intervalDistance >= 0) return false;
        }
        return true;
    }
}