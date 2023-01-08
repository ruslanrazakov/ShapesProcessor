using ShapesProcessor.Lib.Shapes;
using ShapesProcessor.UI.ShapeExtensions;
using ShapesProcessor.UI.Shapes;

namespace ShapesProcessor.UI.Services
{
    public class ForegroundShapesService : IForegroundShapesService
    {
        ShapesProcessor.Lib.ShapesProcessor _processor;
        ILogger<ForegroundShapesService> _logger;

        public ForegroundShapesService(ShapesProcessor.Lib.ShapesProcessor processor, ILogger<ForegroundShapesService> logger)
        {
            _processor = processor;
            _logger = logger;
        }

        /// <summary>
        /// Gets foreground shapes from UI shape entities, using ShapeIntersection lib
        /// maps UI shape entities to Lib shape entities.
        /// </summary>
        /// <param name="UIshapes">UI shape entities list</param>
        /// <returns></returns>
        public List<IShape> GetForegrounds(IEnumerable<IShape> UIshapes)
        {
            var shapesGeometries = UIshapes.ToGeometryPrimitives();

            var foregrounds = _processor.GetForegroundPolygons(shapesGeometries);
            _logger.LogInformation($"{foregrounds.Count} FIGURES RECEIVED FROM PROCESSOR LIBRARY");

            return foregrounds.ToUIShapes();
        }
    }
}
