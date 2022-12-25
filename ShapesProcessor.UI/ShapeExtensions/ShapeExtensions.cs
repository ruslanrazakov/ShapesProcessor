using ShapesIntersection.Shapes;
using ShapesProcessor.UI.Shapes;

namespace ShapesProcessor.UI.ShapeExtensions
{
    public static class ShapeExtensions
    {
        public static Polygon ConvertToGeometry(this Triangle triangle)
            => new Polygon(new Vector[]
                                {
                                    new Vector(triangle.A_x, triangle.A_y),
                                    new Vector(triangle.B_x, triangle.B_y),
                                    new Vector(triangle.C_x, triangle.C_y)
                                })
                                { 
                                    Figure = ShapesIntersection.Shapes.ShapeType.Polygon
                                };

        public static Polygon ConvertToGeometry(this Rectangle rect)
            => new Polygon(new Vector[]
                                {
                                    new Vector(rect.A_x, rect.A_y),
                                    new Vector(rect.B_x, rect.B_y),
                                    new Vector(rect.C_x, rect.C_y),
                                    new Vector(rect.D_x, rect.D_y)
                                })
                                {
                                    Figure = ShapesIntersection.Shapes.ShapeType.Polygon
                                };

        public static ShapesIntersection.Shapes.Circle ConvertToGeometry(this UI.Shapes.Circle circle)
           => new ShapesIntersection.Shapes.Circle(new Vector(circle.X, circle.Y), circle.Radius) 
                                   {
                                       Figure = ShapesIntersection.Shapes.ShapeType.Circle
                                   };

        public static Triangle ToUI_Triangle(this Polygon triangle)
            => new Triangle() 
            {
                A_x = (int)triangle.Points[0].X, A_y = (int)triangle.Points[0].Y,
                B_x = (int)triangle.Points[1].X, B_y = (int)triangle.Points[1].Y,
                C_x = (int)triangle.Points[2].X, C_y = (int)triangle.Points[2].Y,
            };

        public static Rectangle ToUI_Rectangle(this Polygon triangle)
            => new Rectangle()
            {
                A_x = (int)triangle.Points[0].X, A_y = (int)triangle.Points[0].Y,
                B_x = (int)triangle.Points[1].X, B_y = (int)triangle.Points[1].Y,
                C_x = (int)triangle.Points[2].X, C_y = (int)triangle.Points[2].Y,
                D_x = (int)triangle.Points[3].X, D_y = (int)triangle.Points[3].Y,
            };

        public static UI.Shapes.Circle ToUI_Circle(this ShapesIntersection.Shapes.Circle circle)
          => new()
          {
              X = (int)circle.Center.X,
              Y = (int)circle.Center.Y,
              Radius = circle.Radius,
          };

    }
}
