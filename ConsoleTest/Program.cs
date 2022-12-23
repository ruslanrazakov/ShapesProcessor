
using ShapesIntersection;

namespace ConsoleTest
{
    class Program
    {
        static void Main()
        {
            // HasIntersection test
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
            bool areTrianglesIntersect = processor.HasIntersection(triangle1, triangle2);

            Polygon square = new Polygon(new Vector[]
                                   {
                                        new Vector(3, 3),
                                        new Vector(4, 3),
                                        new Vector(4, 4),
                                        new Vector(3, 4),
                                   });
            bool isFirstTriangleIntersectsSquare = processor.HasIntersection(triangle1, square);
            bool isSecondTriangleIntersectsSquare = processor.HasIntersection(triangle2, square);

            //Get foreground polygons test 1
            List<Polygon> pols1 = new()
            {
                triangle1, triangle2, square
            };

            var foregroundPols = processor.GetForegroundPolygons(pols1);

            //Get foreground polygons test 2
            Polygon square1 = new Polygon(new Vector[]
                                            {
                                                new Vector(2, 1),
                                                new Vector(3, 1),
                                                new Vector(3, 2),
                                                new Vector(2, 2),
                                            });

            Polygon square2 = new Polygon(new Vector[]
                                            {
                                                new Vector(5, 1),
                                                new Vector(6, 1),
                                                new Vector(6, 2),
                                                new Vector(5, 2),
                                            });


            Polygon rectangle3 = new Polygon(new Vector[]
                                            {
                                                new Vector(1, 1),
                                                new Vector(7, 1),
                                                new Vector(7, 3),
                                                new Vector(1, 3),
                                            });

            Polygon triangle4 = new Polygon(new Vector[]
                                            {
                                                new Vector(9, 1),
                                                new Vector(10, 3),
                                                new Vector(8, 3)
                                            });

            Polygon rectangle5 = new Polygon(new Vector[]
                                            {
                                                new Vector(3, 2),
                                                new Vector(4, 2),
                                                new Vector(4, 4),
                                                new Vector(3, 4),
                                            });

            List<Polygon> pols2 = new()
            {
                square1, square2, rectangle3, triangle4, rectangle5
            };

            var foregroundPols2 = processor.GetForegroundPolygons(pols2);
        }
    }
}