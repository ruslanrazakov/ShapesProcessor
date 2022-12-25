using System;
using ShapesIntersection.Shapes;

namespace ShapesIntersection;

public class ShapesProcessor
{

    public List<Shape> GetForegroundPolygons(IEnumerable<Shape> shapes)
    {
        List<CollisionObject> collisionObjects = new();

        foreach(var shape in shapes)
        {
            collisionObjects.Add(new CollisionObject(shape));
        }

        List<CollisionObject> noCollisionObjects = new();

        for(int colObjectIndex = 0; colObjectIndex < collisionObjects.Count; colObjectIndex++)
        {
            for(int noCollisIndex = 0; noCollisIndex < noCollisionObjects.Count; noCollisIndex++)
            {
                if(collisionObjects[colObjectIndex].Intersects(noCollisionObjects[noCollisIndex]))
                {
                    Console.WriteLine($"{collisionObjects[colObjectIndex]._shape.Name} INTERSECTS {noCollisionObjects[noCollisIndex]._shape.Name}");
                    Console.WriteLine($"{noCollisionObjects[noCollisIndex]._shape.Name} removed from foregrounds list");

                    noCollisionObjects.RemoveAt(noCollisIndex);
                    noCollisIndex--;
                }
            }
            noCollisionObjects.Add(collisionObjects[colObjectIndex]);
            Console.WriteLine($"{collisionObjects[colObjectIndex]._shape.Name} added to foregrounds list");
        }
        return noCollisionObjects.Select(f=>f._shape).ToList();
    }

    /// <summary>
    /// Use Separating Axis Theorem to check if two polygons intersects
    /// </summary>
    /// <param name="polygon1"></param>
    /// <param name="polygon2"></param>
    /// <returns></returns>
    public bool HasIntersection(Polygon polygon1, Polygon polygon2)
    {
        int pol1EdgesAmount = polygon1.EdgesCount;
        int pol2EdgesAmount = polygon2.EdgesCount;

        int edgesSum = pol1EdgesAmount + pol2EdgesAmount;

        Vector edge;
        for(int edgeIndex = 0; edgeIndex < edgesSum; edgeIndex++)
        {
            if (edgeIndex < pol1EdgesAmount)
                edge = polygon1.Edges[edgeIndex];
            else
                edge = polygon2.Edges[edgeIndex - pol1EdgesAmount];

            //find perpendicular for the current edge
            var axis = new Vector(-edge.Y, edge.X);
            axis.Normalize();

            float min1 = 0; float min2 = 0; float max1 = 0; float max2 = 0;

            //poject polygons on axis
            ProjectPolygon(axis, polygon1, ref min1, ref max1);
            ProjectPolygon(axis, polygon2, ref min2, ref max2);

            if (IntervalDistance(min1, max1, min2, max2) > 0) return false;
        }

        return true;
    }

    /// <summary>
    /// Use Polygon circle collision detection algorythm to check if  polygons intersects circle
    /// </summary>
    /// <param name="polygon1"></param>
    /// <param name="circle"></param>
    /// <returns></returns>
    public bool HasIntersection(Polygon polygon, Circle circle)
    {
        List<Vector> normals = new List<Vector>();

        foreach(var edge in polygon.Edges)
        {
            normals.Add(edge.Normalize());
        }

        normals.Add(GetPolygonCircleAxis(polygon, circle));
        foreach (Vector axis in normals)
        {
            float min1 = 0; float min2 = 0; float max1 = 0; float max2 = 0;
            ProjectPolygon(axis, polygon, ref min1, ref max1);
            ProjectPolygon(axis, circle, ref min2, ref max2);
            float intervalDistance = min1 < min2 ? min2 - max1 : min1 - max2;
            if (intervalDistance >= 0) return false;
        }
        return true;
    }

    /// <summary>
    /// Use circle projection on line to check if line intersects circle
    /// Line AB and circle in point C
    /// </summary>
    /// <param name="line"></param>
    /// <param name="circle"></param>
    /// <returns></returns>
    public bool HasIntersection(Polygon line, Circle circle, bool isline)
    {
        Vector lineStart = line.Points[0];
        Vector lineEnd = line.Points[1];

        Vector ac = circle.Center - lineStart;
        Vector ab = lineEnd - lineStart;

        float ab2 = ab.DotProduct(ab);
        float acab = ac.DotProduct(ab);
        float t = acab / ab2;

        if (t < 0)
            t = 0;
        else if (t > 1)
            t = 1;

        Vector h = ((ab * t) + lineStart) - circle.Center;
        float h2 = h.DotProduct(h);

        return (h2 <= (circle.Radius * circle.Radius));
    }

    public bool HasIntersection(Circle circle1, Circle circle2)
    {
        Vector dv = circle2.Center - circle1.Center;
        return dv.X * dv.X + dv.Y * dv.Y <= MathF.Pow(circle1.Radius + circle2.Radius, 2);
    }

    /// <summary>
    /// Checks polygon projection on axis and gets minimum and maximum interval
    /// </summary>
    /// <param name="axis"></param>
    /// <param name="polygon"></param>
    /// <param name="min"></param>
    /// <param name="max"></param>
    private void ProjectPolygon(Vector axis, Polygon polygon, ref float min, ref float max)
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

    /// <summary>
    /// Checks circle projection on axis and gets minimum and maximum interval
    /// </summary>
    /// <param name="axis"></param>
    /// <param name="polygon"></param>
    /// <param name="min"></param>
    /// <param name="max"></param>
    private void ProjectPolygon(Vector axis, Circle circle, ref float min, ref float max)
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

    private Vector GetPolygonCircleAxis(Polygon polygon, Circle circle)
    {
        Vector nearestVertex = FindClosestVertex(polygon, circle.Center);
        Vector axis = circle.Center - nearestVertex;
        Vector perp = new Vector(axis.Y, -axis.X);
        return perp;
    }

    private Vector FindClosestVertex(Polygon polygon, Vector vertex)
    {
        float shortestDistance = Int32.MaxValue;
        Vector closestVertex = polygon.Points[0];
        foreach (var polygonVertex in polygon.Points)
        {
            float currentDistance =  vertex.DistanceSquared(polygonVertex);
            if (currentDistance < shortestDistance)
            {
                closestVertex = polygonVertex;
                shortestDistance = currentDistance;
            }
        }
        return closestVertex;
    }

    private Vector Project(Vector vertex, Vector axis)
    {
        float dot = vertex.DotProduct(axis);
        float mag = axis.LengthSquared();
        return dot / mag * axis;
    }

    /// <summary>
    /// Calculate min and max distance between the intervals
    /// The distance will be negative if the intervals overlap
    /// </summary>
    /// <param name="min1"></param>
    /// <param name="max1"></param>
    /// <param name="min2"></param>
    /// <param name="max2"></param>
    /// <returns></returns>
    private float IntervalDistance(float min1, float max1, float min2, float max2)
        => min1 < min2 ? min2 - max1 : min1 - max2;
}
