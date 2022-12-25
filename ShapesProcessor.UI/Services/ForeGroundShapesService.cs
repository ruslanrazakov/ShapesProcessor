using ShapesIntersection.Shapes;
using ShapesProcessor.UI.ShapeExtensions;
using ShapesProcessor.UI.Shapes;

namespace ShapesProcessor.UI.Services
{
    public class ForegroundShapesService : IForegroundShapesService
    {
        ShapesIntersection.ShapesProcessor _processor;
        ILogger<ForegroundShapesService> _logger;

        public ForegroundShapesService(ShapesIntersection.ShapesProcessor processor, ILogger<ForegroundShapesService> logger)
        {
            _processor = processor;
            _logger = logger;
        }

        /// <summary>
        /// Gets foreground shapes from UI shape entities, using ShapeIntersection lib
        /// maps UI shape entities to Lib shape entities.
        /// </summary>
        /// <param name="shapes">UI shape entities list</param>
        /// <returns></returns>
        public List<IShape> GetForegrounds(IEnumerable<IShape> shapes)
        {
            //TODO: create mapper service for this stuff
            List<ShapesIntersection.Shapes.Shape> shapesGeometries = new();
            foreach(var shape in shapes)
            {
                if(shape.Type == UI.Shapes.ShapeType.Triangle)
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

            var foregrounds = _processor.GetForegroundPolygons(shapesGeometries);
            _logger.LogInformation($"{foregrounds.Count} FIGURES RECEIVED FROM LIBRARY");


            List<IShape> UIShapes = new();
            foreach (var shape in foregrounds)
            {
                if(shape.Figure == ShapesIntersection.Shapes.ShapeType.Polygon)
                {
                    var polygon = (Polygon)shape;

                    if (polygon.PointsCount == 3)
                    {
                        UIShapes.Add(polygon.ToUI_Triangle());
                    }
                    else if(polygon.PointsCount == 4)
                    {
                        UIShapes.Add(polygon.ToUI_Rectangle());
                    }
                }
                else
                {
                    var circle = (ShapesIntersection.Shapes.Circle)shape;
                    UIShapes.Add(circle.ToUI_Circle());
                }
            }
            return UIShapes;
        }
    }
}
