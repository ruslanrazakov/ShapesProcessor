using ShapesIntersection.Shapes;
using ShapesProcessor.UI.Shapes;

namespace ShapesProcessor.UI.Services
{
    public interface IForegroundShapesService
    {
        List<UI.Shapes.IShape> GetForegrounds(IEnumerable<UI.Shapes.IShape> shapes);
    }
}
