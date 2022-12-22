using System.Drawing;
using System;

namespace ShapesIntersection;

public struct Polygon : IShape
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
}
