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

            float min1 = 0; float min2 = 0; float max1 = 0; float max2 = 0;
            ProjectPolygon(axis, polygon1, ref min1, ref max1);
            ProjectPolygon(axis, polygon2, ref min2, ref max2);

            if (IntervalDistance(min1, max1, min2, max2) > 0)
                return false;
        }

        return true;
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
            else
            {
                if (dotProduct > max)
                {
                    max = dotProduct;
                }
            }
        }
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
