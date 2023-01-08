using ShapesProcessor.UI.Shapes;

namespace ShapesProcessor.UI.Shapes
{
    public class Rectangle : IShape
    {
        public ShapeType Type => ShapeType.Rectangle;

        public int A_x { get; set; }
        public int A_y { get; set; }
        public int B_x { get; set; }
        public int B_y { get; set; }
        public int C_x { get; set; }
        public int C_y { get; set; }
        public int D_x { get; set; }
        public int D_y { get; set; }
    }
}
