
using ShapesIntersection;
using ShapesIntersection.Shapes;

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
            bool isTrianglesIntersect = processor.HasIntersection(triangle1, triangle2);
           Console.WriteLine( triangle1.Intersect(triangle2));

            Polygon squis = new Polygon(new Vector[]
                                   {
                                        new Vector(3, 3),
                                        new Vector(4, 3),
                                        new Vector(4, 4),
                                        new Vector(3, 4),
                                   });
            bool isFirstTriangleIntersectsSquis = processor.HasIntersection(triangle1, squis);
            bool isSecondTriangleIntersectsSquis = processor.HasIntersection(triangle2, squis);
            
            

            List<Polygon> pols1 = new()
            {
                triangle1, triangle2, squis
            };

            var foregroundPols = processor.GetForegroundPolygons(pols1);



            // Foreground polygons test 2
            Console.WriteLine("**********************************************************");
            Polygon squis1 = new Polygon(new Vector[]
                                            {
                                                new Vector(2, 1),
                                                new Vector(3, 1),
                                                new Vector(3, 2),
                                                new Vector(2, 2),
                                            });
            squis1.Guid = "1";

            Polygon squis2 = new Polygon(new Vector[]
                                            {
                                                new Vector(5, 1),
                                                new Vector(6, 1),
                                                new Vector(6, 2),
                                                new Vector(5, 2),
                                            });
            squis2.Guid = "2";

            Polygon rectangle3 = new Polygon(new Vector[]
                                            {
                                                new Vector(1, 1),
                                                new Vector(7, 1),
                                                new Vector(7, 3),
                                                new Vector(1, 3),
                                            });
            rectangle3.Guid = "3";
            Polygon triangle4 = new Polygon(new Vector[]
                                            {
                                                new Vector(9, 1),
                                                new Vector(10, 3),
                                                new Vector(8, 3)
                                            });
            triangle4.Guid = "4";
            Polygon rectangle5 = new Polygon(new Vector[]
                                            {
                                                new Vector(3, 2),
                                                new Vector(4, 2),
                                                new Vector(4, 4),
                                                new Vector(3, 4),
                                            });

            rectangle5.Guid = "5";
            Circle circl = new Circle(new Vector(8, 4), 2);
            circl.Guid = "6";
            List<Shape> pols2 = new()
            {
                squis1, squis2, rectangle3, triangle4, rectangle5, circl
            };

            var foregroundPols2 = processor.GetForegroundPolygons(pols2);


            // Circle polygon intersection test
            Circle circle = new Circle(new Vector(2, 3), 1);
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
            List<Shape> pols3 = new()
            {
                p1, circle, p2, p3, p4
            };

            var dssd = processor.GetForegroundPolygons(pols3);

            bool isCircleAndP1Intersect = processor.HasIntersection(p1, circle);
            bool isCircleAndP2Intersect = processor.HasIntersection(p2, circle);
            bool isCircleAndP3Intersect = processor.HasIntersection(p3, circle);
            bool isCircleAndP4Intersect = processor.HasIntersection(p4, circle);


            // Circle circle intersection test
            Circle circle1 = new Circle(new Vector(2, 2), 1);
            Circle circle2 = new Circle(new Vector(3, 2), 1);
            Circle circle3 = new Circle(new Vector(4.5f, 2), 1);

            List<Shape>shapes = new List<Shape>(){circle1, circle2, circle3};

            var fcirclesIntersection = processor.GetForegroundPolygons(shapes);


            bool isCircle1AndCircle2Intersect = processor.HasIntersection(circle1, circle2);
            bool isCircle2AndCircle3Intersect = processor.HasIntersection(circle2, circle3);
            bool isCircle1AndCircle3Intersect = processor.HasIntersection(circle1, circle3);

            //Lines and polygons intersection test
            Polygon line1 = new Polygon(new Vector[] {new Vector(1,1), new Vector(5,1)});
            Polygon line2 = new Polygon(new Vector[] {new Vector(1,3), new Vector(5,3)});
            Polygon line3 = new Polygon(new Vector[] {new Vector(4,2), new Vector(1,4)});
            Polygon line4 = new Polygon(new Vector[] {new Vector(1,5), new Vector(5,5)});

            Polygon p5 = new Polygon(new Vector[]
                                            {
                                                new Vector(1, 4),
                                                new Vector(2, 4),
                                                new Vector(2, 5),
                                                new Vector(1, 5),
                                            });

            bool isLine1AndPolygonIntersect = processor.HasIntersection(line1, p5);
            bool isLine2AndPolygonIntersect = processor.HasIntersection(line2, p5);
            bool isLine3AndPolygonIntersect = processor.HasIntersection(line3, p5);

            //lines and shapes intersection test
            Circle circle4 = new Circle(new Vector(3,3), 1);

            bool isLine1AndCircle4Intersect = processor.HasIntersection(line1, circle4, true);
            bool isLine2AndCircle4Intersect = processor.HasIntersection(line2, circle4, true);
            bool isLine3AndCircle4Intersect = processor.HasIntersection(line3, circle4, true);
            bool isLine4AndCircle4Intersect = processor.HasIntersection(line4, circle4, true);
        }
    }
}