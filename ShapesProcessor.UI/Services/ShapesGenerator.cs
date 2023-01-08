using ShapesProcessor.UI.Shapes;

namespace ShapesProcessor.UI.Services
{
	public class ShapesGenerator : IShapesGenerator
	{
		public List<IShape> GetRandom(int amount, int width, int height)
		{
            Random random = new Random();
            List<IShape> randomShapes = new();

            foreach (var shape in Enumerable.Range(0, 15))
            {
                int rectangleWidth = random.Next(0, 200);
                int rectangleHeight = random.Next(0, 200);
                int rectangleSpawnX = random.Next(0, width);
                int rectangleSpawnY = random.Next(0, width);

                int triangleSpawnX = random.Next(0, width);
                int triangleSpawnY = random.Next(0, width);
                int triangleWidth = random.Next(triangleSpawnX, triangleSpawnX + 200);
                int triangleHeight = random.Next(0, 200);
                int triangleBaseY = triangleSpawnY - triangleHeight;

                int choose = random.Next(1, 4);
                if (choose == 1)
                {
                    randomShapes.Add(new Rectangle()
                    {
                        A_x = rectangleSpawnX,
                        A_y = rectangleSpawnY,
                        B_x = rectangleSpawnX + rectangleWidth,
                        B_y = rectangleSpawnY,
                        C_x = rectangleSpawnX + rectangleWidth,
                        C_y = rectangleSpawnY + rectangleHeight,
                        D_x = rectangleSpawnX,
                        D_y = rectangleSpawnY + rectangleHeight,
                    });
                }
                else if (choose == 2)
                {
                    randomShapes.Add(new Circle()
                    {
                        Radius = random.Next(0, 100),
                        X = random.Next(0, width),
                        Y = random.Next(0, height),
                    });
                }
                else if (choose == 3)
                {
                    randomShapes.Add(new Triangle()
                    {
                        A_x = triangleSpawnX,
                        A_y = triangleSpawnY,
                        B_x = triangleSpawnX + triangleHeight,
                        B_y = triangleBaseY,
                        C_x = triangleSpawnX - triangleHeight,
                        C_y = triangleBaseY,
                    });
                }
            }
            return randomShapes;
        }
    }
}
