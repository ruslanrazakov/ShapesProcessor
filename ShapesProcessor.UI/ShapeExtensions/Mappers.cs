using ShapesProcessor.Lib.Shapes;
using ShapesProcessor.UI.Shapes;

namespace ShapesProcessor.UI.ShapeExtensions
{
	public static class Mappers
	{
        /// <summary>
        /// Converts UI list from view to shapes geometry primitives list
        /// </summary>
        /// <param name="shapes"></param>
        /// <returns></returns>
		public static List<ShapesProcessor.Lib.Shapes.Shape> ToGeometryPrimitives(this IEnumerable<IShape> shapes)
		{
            List<ShapesProcessor.Lib.Shapes.Shape> shapesGeometries = new();
            foreach (var shape in shapes)
            {
                if (shape.Type == UI.Shapes.ShapeType.Triangle)
                {
                    var triangle = (Triangle)shape;
                    shapesGeometries.Add(triangle.ConvertToGeometry());
                }
                if (shape.Type == UI.Shapes.ShapeType.Circle)
                {
                    var circle = (UI.Shapes.Circle)shape;
                    shapesGeometries.Add(circle.ConvertToGeometry());
                }
                if (shape.Type == UI.Shapes.ShapeType.Rectangle)
                {
                    var rectangle = (Rectangle)shape;
                    shapesGeometries.Add(rectangle.ConvertToGeometry());
                }
            }
            return shapesGeometries;
        }

        /// <summary>
        /// Converts shape geometry primitives to UI shapes for view
        /// </summary>
        /// <param name="shapes"></param>
        /// <returns></returns>
        public static List<ShapesProcessor.UI.Shapes.IShape> ToUIShapes(this IEnumerable<ShapesProcessor.Lib.Shapes.Shape> shapes)
        {
            List<IShape> UIShapes = new();
            foreach (var shape in shapes)
            {
                if (shape.Figure == ShapesProcessor.Lib.Shapes.ShapeType.Polygon)
                {
                    var polygon = (Polygon)shape;

                    if (polygon.PointsCount == 3)
                    {
                        UIShapes.Add(polygon.ToUI_Triangle());
                    }
                    else if (polygon.PointsCount == 4)
                    {
                        UIShapes.Add(polygon.ToUI_Rectangle());
                    }
                }
                else
                {
                    var circle = (ShapesProcessor.Lib.Shapes.Circle)shape;
                    UIShapes.Add(circle.ToUI_Circle());
                }
            }
            return UIShapes;
        }
    }
}
