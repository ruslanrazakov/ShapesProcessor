
using ShapesIntersection;

namespace ConsoleTest
{
    class Program
    {
        static void Main()
        {
            Polygon triangle1 = new Polygon(new Vector[] 
                                    { 
                                        new Vector(1, 1),
                                        new Vector(3, 1),
                                        new Vector(2, 3)
                                    });

            Polygon triangle2 = new Polygon(new Vector[]
                                    {
                                        new Vector(2, 2),
                                        new Vector(4, 2),
                                        new Vector(3, 4)
                                    });

            ShapesProcessor processor = new();
            bool areTrianglesIntersect = processor.GetIntersection(triangle1, triangle2);

            Polygon square = new Polygon(new Vector[]
                                   {
                                        new Vector(3, 3),
                                        new Vector(4, 3),
                                        new Vector(3, 4),
                                        new Vector(4, 4),
                                   });
            bool isFirstTriangleIntersectsSquare = processor.GetIntersection(triangle1, square);
            bool isSecondTriangleIntersectsSquare = processor.GetIntersection(triangle2, square);

        }
    }
}