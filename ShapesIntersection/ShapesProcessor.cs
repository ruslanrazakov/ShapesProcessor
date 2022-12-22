using System;

namespace ShapesIntersection;

public class ShapesProcessor
{
    /// <summary>
    /// Use Separating Axis Theorem to check if two polygons intersects
    /// </summary>
    /// <param name="polygon1"></param>
    /// <param name="polygon2"></param>
    /// <returns></returns>
    public bool GetIntersection(Polygon polygon1, Polygon polygon2)
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

            float minA = 0; float minB = 0; float maxA = 0; float maxB = 0;
            ProjectPolygon(axis, polygon1, ref minA, ref maxA);
            ProjectPolygon(axis, polygon2, ref minB, ref maxB);

            if (IntervalDistance(minA, maxA, minB, maxB) > 0)
                return false;
        }

        return true;
    }

    private float IntervalDistance(float minA, float maxA, float minB, float maxB)
        => minA < minB ? minB - maxA : minA - maxB;

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
            else
            {
                if (dotProduct > max)
                {
                    max = dotProduct;
                }
            }
        }
    }
}
