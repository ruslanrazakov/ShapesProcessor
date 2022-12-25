using System;
using ShapesIntersection.Shapes;

namespace ShapesIntersection;

public class ShapesProcessor
{
    /// <summary>
    /// Searchs for foreground shapes in shape input stream
    /// returns foreground shapes list
    /// </summary>
    /// <param name="shapes"></param>
    /// <returns></returns>
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
                    noCollisionObjects.RemoveAt(noCollisIndex);
                    noCollisIndex--;
                }
            }
            noCollisionObjects.Add(collisionObjects[colObjectIndex]);
        }
        return noCollisionObjects.Select(f=>f._shape).ToList();
    }
}
