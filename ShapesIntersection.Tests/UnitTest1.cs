using ShapesIntersection.Shapes;

namespace ShapesIntersection.Tests
{
	public class Tests
	{
		ShapesProcessor processor = new();

		Polygon triangle1;
		Polygon triangle2;
		Polygon triangle3;
		Polygon rectangle1;
		Polygon rectangle2;
		Polygon rectangle3;
		Polygon rectangle4;
		Polygon rectangle5;
		Polygon square1;
		Circle circle1;

		[SetUp]
		public void Setup()
		{
			triangle1 = new Polygon(new Vector[]
								   {
										new Vector(1, 1),
										new Vector(3, 1),
										new Vector(2, 3)
								   })
			{ Guid = "Triangle1" };

			triangle2 = new Polygon(new Vector[]
									{
										new Vector(2, 2),
										new Vector(4, 2),
										new Vector(3, 4)
									})
			{ Guid = "Triangle2" };

			triangle3 = new Polygon(new Vector[]
								   {
										new Vector(3, 3),
										new Vector(4, 3),
										new Vector(4, 4),
										new Vector(3, 4),
								   })
			{ Guid = "Triangle3" };

			square1 = new Polygon(new Vector[]
								   {
										new Vector(3, 3),
										new Vector(4, 3),
										new Vector(4, 4),
										new Vector(3, 4),
								   })
			{ Guid = "Square1" };

			rectangle1 = new Polygon(new Vector[]
										   {
												new Vector(2, 1),
												new Vector(3, 1),
												new Vector(3, 2),
												new Vector(2, 2),
										   })
			{ Guid = "Rectangle1" };

			rectangle2 = new Polygon(new Vector[]
											{
												new Vector(5, 1),
												new Vector(6, 1),
												new Vector(6, 2),
												new Vector(5, 2),
											})
			{ Guid = "Rectangle2" };

			rectangle3 = new Polygon(new Vector[]
											{
												new Vector(1, 1),
												new Vector(7, 1),
												new Vector(7, 3),
												new Vector(1, 3),
											})
			{ Guid = "Rectangle3" };

			rectangle4 = new Polygon(new Vector[]
											{
												new Vector(9, 1),
												new Vector(10, 3),
												new Vector(8, 3)
											})
			{ Guid = "Rectangle4" };

			rectangle5 = new Polygon(new Vector[]
											{
												new Vector(3, 2),
												new Vector(4, 2),
												new Vector(4, 4),
												new Vector(3, 4),
											})
			{ Guid = "Rectangle5" };

			circle1 = new Circle(new Vector(8, 4), 2)
			{ Guid = "Circle1" };

		}

		[Test]
		public void EdgesInPolygonCreatingTest()
		{
			Assert.IsTrue(triangle1.EdgesCount == triangle1.PointsCount);
			Assert.IsTrue(square1.EdgesCount == square1.PointsCount);
			Assert.IsTrue(rectangle1.EdgesCount == rectangle1.PointsCount);
		}

		[Test]
		public void PolygonIntersectionCommutativeTest()
		{
			Assert.IsTrue(triangle1.Intersect(triangle2));
			Assert.IsTrue(triangle2.Intersect(triangle1));

			Assert.IsFalse(triangle1.Intersect(triangle3));
			Assert.IsFalse(triangle3.Intersect(triangle1));
		}

		[Test]
		public void PolygonsForegroundSearchTest1()
		{
			List<Polygon> pols1 = new()
			{
				triangle1, triangle2, triangle3, square1
			};

			var foregroundShapes = processor.GetForegroundPolygons(pols1);
			Assert.That(foregroundShapes.Count == 1 && foregroundShapes.First().Guid == "Square1", Is.True);
		}

		[Test]
		public void ShapesForegroundSearchTest()
		{
			List<Shape> pols2 = new()
			{
				rectangle1, rectangle2, rectangle3, rectangle4, rectangle5, circle1
			};

			var foregroundShapes = processor.GetForegroundPolygons(pols2);

			List<string> shapeNames = new();
			foreach(var shape in foregroundShapes)
			{
				shapeNames.Add(shape.Guid);
			}

			Assert.That(shapeNames.Count == 2, Is.True);
			Assert.That(shapeNames[0] == "Rectangle5" && shapeNames[1] == "Circle1", Is.True);
		}
	}
}