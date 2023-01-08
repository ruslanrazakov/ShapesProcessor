using ShapesProcessor.UI.Shapes;

namespace ShapesProcessor.UI.Services
{
	public interface IShapesGenerator
	{
		public List<IShape> GetRandom(int amount, int width, int height);

	}
}
