
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

            // Foreground polygons test 1
            List<Polygon> pols1 = new()
            {
                triangle1, triangle2, square
            };

            var foregroundPols = processor.GetForegroundPolygons(pols1);

            // Foreground polygons test 2
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


            // Circle polygon intersection test
            Circle circle = new Circle(new Vector(2, 2), 1);
            Polygon p1 = new Polygon(new Vector[]
                                            {
                                                new Vector(1, 1),
                                                new Vector(3, 1),
                                                new Vector(3, 3),
                                                new Vector(1, 3),
                                            });

            Polygon p2 = new Polygon(new Vector[]
                                            {
                                                new Vector(5, 5),
                                                new Vector(6, 5),
                                                new Vector(6, 6),
                                                new Vector(5, 6),
                                            });

            Polygon p3 = new Polygon(new Vector[]
                                            {
                                                new Vector(4, 1),
                                                new Vector(5, 1),
                                                new Vector(5, 2),
                                                new Vector(4, 2),
                                            });

            Polygon p4 = new Polygon(new Vector[]
                                            {
                                                new Vector(2, 2),
                                                new Vector(4, 2),
                                                new Vector(4, 4),
                                                new Vector(2, 4),
                                            });


            bool areCircleAndP1Intersect = processor.HasIntersection(p1, circle);
            bool areCircleAndP2Intersect = processor.HasIntersection(p2, circle);
            bool areCircleAndP3Intersect = processor.HasIntersection(p3, circle);
            bool areCircleAndP4Intersect = processor.HasIntersection(p4, circle);


            // Circle circle intersection test
            Circle circle1 = new Circle(new Vector(2, 2), 1);
            Circle circle2 = new Circle(new Vector(3, 2), 1);
            Circle circle3 = new Circle(new Vector(4.5f, 2), 1);

            bool areCircle1AndCircle2Intersect = processor.HasIntersection(circle1, circle2);
            bool areCircle2AndCircle3Intersect = processor.HasIntersection(circle2, circle3);
            bool areCircle1AndCircle3Intersect = processor.HasIntersection(circle1, circle3);

        }
    }
}