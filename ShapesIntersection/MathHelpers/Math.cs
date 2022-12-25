using ShapesIntersection.Shapes;

namespace ShapesIntersection.MathHelpers;

public static class Polygons
{
    /// <summary>
    /// Checks polygon projection on axis and gets minimum and maximum interval
    /// </summary>
    /// <param name="axis"></param>
    /// <param name="polygon"></param>
    /// <param name="min"></param>
    /// <param name="max"></param>
    public static void ProjectPolygon(Vector axis, Polygon polygon, ref float min, ref float max)
    {
        float dotProduct = axis.DotProduct(polygon.Points[0]);
        min = dotProduct;
        max = dotProduct;
        for (int i = 0; i < polygon.PointsCount; i++)
        {
            dotProduct = polygon.Points[i].DotProduct(axis);
            if (dotProduct < min)
            {
                min = dotProduct;
            }
            else if (dotProduct > max)
            {
                max = dotProduct;
            }
        }
    }

    public static float IntervalDistance(float min1, float max1, float min2, float max2)
        => min1 < min2 ? min2 - max1 : min1 - max2;

    public static Vector GetPolygonCircleAxis(Polygon polygon, Circle circle)
    {
        Vector nearestVertex = FindClosestVertex(polygon, circle.Center);
        Vector axis = circle.Center - nearestVertex;
        Vector perp = new Vector(axis.Y, -axis.X);
        return perp;
    }

    public static Vector FindClosestVertex(Polygon polygon, Vector vertex)
    {
        float shortestDistance = Int32.MaxValue;
        Vector closestVertex = polygon.Points[0];
        foreach (var polygonVertex in polygon.Points)
        {
            float currentDistance = vertex.DistanceSquared(polygonVertex);
            if (currentDistance < shortestDistance)
            {
                closestVertex = polygonVertex;
                shortestDistance = currentDistance;
            }
        }
        return closestVertex;
    }

    /// <summary>
    /// Checks circle projection on axis and gets minimum and maximum interval
    /// </summary>
    /// <param name="axis"></param>
    /// <param name="polygon"></param>
    /// <param name="min"></param>
    /// <param name="max"></param>
    public static void ProjectPolygon(Vector axis, Circle circle, ref float min, ref float max)
    {
        Vector v1 = circle.Center - axis.Normalize() * circle.Radius;
        Vector v2 = circle.Center + axis.Normalize() * circle.Radius;
        Vector p1 = Project(v1, axis);
        Vector p2 = Project(v2, axis);
        float s1 = p1.DotProduct(axis);
        float s2 = p2.DotProduct(axis);
        if (s1 > s2)
        {
            min = s2;
            max = s1;
        }
        else
        {
            min = s1;
            max = s2;
        }
    }

    /// <summary>
    /// Gets projection for circle
    /// </summary>
    /// <param name="vertex"></param>
    /// <param name="axis"></param>
    /// <returns></returns>
    public static Vector Project(Vector vertex, Vector axis)
    {
        float dot = vertex.DotProduct(axis);
        float mag = axis.LengthSquared();
        return dot / mag * axis;
    }
}