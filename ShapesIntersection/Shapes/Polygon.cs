using System.Drawing;
using System;

namespace ShapesIntersection.Shapes;

public class Polygon : Shape
{
    public Vector[] Points { get; }
    public int PointsCount => Points.Length;
    public Vector[] Edges => _edges;
    public int EdgesCount => _edges.Length;

    private Vector[] _edges;

    public Polygon(Vector[] points)
    {
        Points = points;

        // fill edges
        _edges = new Vector[points.Length];
        Vector point1;
        Vector point2;
        for (int i = 0; i < points.Length; i++)
        {
            point1 = points[i];
            
            // if last edge is creating, then its end must be
            // first point in the polygon
            if (i + 1 >= points.Length)
                point2 = points[0];
            else
                point2 = points[i + 1];

            _edges[i] = point2 - point1;
        }
    }

    public override bool IntersectVisit(Shape other)
    {
        return other.Intersect(this);
    }

    public override bool Intersect(Circle circle)
    {
        var normals = new List<Vector>();

        foreach (var edge in this.Edges)
        {
            normals.Add(edge.Normalize());
        }

        normals.Add(MathHelpers.Polygons.GetPolygonCircleAxis(this, circle));
        foreach (Vector axis in normals)
        {
            float min1 = 0; float min2 = 0; float max1 = 0; float max2 = 0;
            MathHelpers.Polygons.ProjectPolygon(axis, this, ref min1, ref max1);
            MathHelpers.Polygons.ProjectPolygon(axis, circle, ref min2, ref max2);
            float intervalDistance = min1 < min2 ? min2 - max1 : min1 - max2;
            if (intervalDistance >= 0) return false;
        }
        return true;
    }

    public override bool Intersect(Polygon other)
    {
        int pol1EdgesAmount = this.EdgesCount;
        int pol2EdgesAmount = other.EdgesCount;

        int edgesSum = pol1EdgesAmount + pol2EdgesAmount;

        Vector edge;
        for (int edgeIndex = 0; edgeIndex < edgesSum; edgeIndex++)
        {
            if (edgeIndex < pol1EdgesAmount)
                edge = this.Edges[edgeIndex];
            else
                edge = other.Edges[edgeIndex - pol1EdgesAmount];

            //find perpendicular for the current edge
            var axis = new Vector(-edge.Y, edge.X);
            axis.Normalize();

            float min1 = 0; float min2 = 0; float max1 = 0; float max2 = 0;

            //poject polygons on axis
            MathHelpers.Polygons.ProjectPolygon(axis, this, ref min1, ref max1);
            MathHelpers.Polygons.ProjectPolygon(axis, other, ref min2, ref max2);
            if (MathHelpers.Polygons.IntervalDistance(min1, max1, min2, max2) > 0) return false;
        }

        return true;
    }
}
