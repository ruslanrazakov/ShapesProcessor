using ShapesIntersection.Shapes;

namespace ShapesProcessor.UI.Shapes
{
    public class Circle : IShape
    {
        public ShapeType Type => ShapeType.Circle;

        public int X { get; set; }
        public int Y { get; set; }
        public float Radius { get; set; }
    }
}
