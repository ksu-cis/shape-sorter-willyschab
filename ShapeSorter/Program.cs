using System;
using System.Collections.Generic;
using System.Linq;

namespace ShapeSorter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Fun With Shapes!");

            List<IShape> shapes = new List<IShape>() {
                new Circle(4.0),
                new Rectangle(6, 7),
                new Square(5.0),
                new Circle(3.0),
                new Rectangle(2.0, 4.0),
                new Circle(3.0),
                new Square(4.0)
            };

            foreach(IShape shape in shapes)
            {
                Console.WriteLine($"Area of shape is {shape.Area}");
            }
            Console.WriteLine("------------------------");

            IEnumerable<IShape> filteredShapes = shapes.Where(shape => shape.Area > 50);
            Console.WriteLine("Shapes with an area > 50");
            foreach (IShape shape in filteredShapes)
            {
                Console.WriteLine($"Area of shape is {shape.Area}");
            }
            Console.WriteLine("------------------------");

            IEnumerable<Circle> circles = shapes.OfType<Circle>();
            Console.WriteLine("All Circles");
            foreach (Circle shape in circles)
            {
                Console.WriteLine($"Circles with radius {shape.Radius} and area  of {shape.Area}");
            }
            Console.WriteLine("------------------------");

            IEnumerable<Circle> filteredCircles = shapes.OfType<Circle>().Where(circle => circle.Radius < 30);
            Console.WriteLine("Circles < 30");
            foreach (Circle shape in filteredCircles)
            {
                Console.WriteLine($"Circles with radius {shape.Radius} and area  of {shape.Area}");
            }
            Console.WriteLine("------------------------");


            Console.WriteLine("Group BY type");
            var groupByArea = shapes.GroupBy(shape => shape.Area % 2 == 0);
            Console.WriteLine(groupByArea.GetType());
            foreach (var group in groupByArea)
            {
                Console.WriteLine(group.Key ? "Evens" : "Odds");
                foreach(var shape in group)
                {
                    Console.WriteLine($"Shape with area {shape.Area}");
                }
            }
            Console.WriteLine("------------------------");

            Console.WriteLine("Group By Type");
            var groupByType = shapes.GroupBy(shape => shape.GetType()).OrderBy(shape  => shape.GetType());
            foreach(var group in groupByType)
            {
                Console.WriteLine($"Shapes of type {group.Key}");
                foreach(var shape in group)
                {
                    Console.WriteLine($"{group.Key.Name} Shape with area {shape.Area}");
                }
            }
            Console.WriteLine("------------------------");


            Console.ReadKey();
        }
    }
}
