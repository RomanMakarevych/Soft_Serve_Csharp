using System.Collections.Generic;
using System.ComponentModel;

namespace Home_Work_8
{


    abstract class Shape : IComparable<Shape>
    {

        public string Name { get; set; }

        public Shape(string name)
        {
            this.Name = name;
        }
        public abstract double Area();
        public abstract double Perimeter();

        public override string ToString()
        {
            return $"The Shape: {Name} , Area: {Area()} cm^2, Perimeter: {Perimeter()} cm  ";
        }

        public int CompareTo(Shape? other)
        {
            return Area().CompareTo(other.Area());
        }
    }
    class Circle : Shape
    {
        private int radius;
        public int Radius { get; set; }

        public Circle(string name, int radius) : base(name)
        {
            this.radius = radius;
        }

        public override double Area()
        {
            return Math.Round((Math.PI * Math.Pow(radius, 2)), 2);
        }

        public override double Perimeter()
        {
            return Math.Round((2 * Math.PI * radius), 2);
        }

    }
    class Square : Shape
    {
        private int side;
        public int Side { get; set; }
        public Square(string name, int side) : base(name)
        {
            this.side = side;
        }

        public override double Area()
        {
            double area = Math.Pow(side, 2);
            return area;
        }

        public override double Perimeter()
        {
            double perimeter = 4 * side;
            return perimeter;
        }
    }
    internal class Program
    {

        public static void WriteLine(string str, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(str);
            Console.ResetColor();
        }
        static void AddShapes(List<Shape> shapes)
        {
            WriteLine("\n\t\tEnter data of 10 diffent shapes.\n", ConsoleColor.Red);

            for (int i = 0; i < 3;)
            {
                try
                {

                    WriteLine("Enter the name of shapes:", ConsoleColor.Cyan);
                    Console.ForegroundColor = ConsoleColor.Green;
                    string? name = Console.ReadLine();
                    WriteLine("Enter 1 for Circle or 2 for Square: ", ConsoleColor.Cyan);
                    Console.ForegroundColor = ConsoleColor.Green;
                    int shapeType = int.Parse(Console.ReadLine());

                    if (shapeType == 1)
                    {
                        WriteLine("Enter the radius: ", ConsoleColor.Cyan);
                        Console.ForegroundColor = ConsoleColor.Green;
                        int radius = int.Parse(Console.ReadLine());
                        Circle circle = new(name, radius);
                        shapes.Add(circle);
                        i++;
                    }
                    else if (shapeType == 2)
                    {
                        WriteLine("Enter the side: ", ConsoleColor.Cyan);
                        Console.ForegroundColor = ConsoleColor.Green;
                        int side = int.Parse(Console.ReadLine());
                        Square square = new(name, side);
                        shapes.Add(square);
                        i++;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        throw new ArgumentException("Invalid shape type. Please enter 1 for Circle or 2 for Square.");
                    }

                }
                catch (FormatException)
                {
                    WriteLine("Invalid input format. Please enter a valid number.", ConsoleColor.Red);
                }
                catch (ArgumentException ex)
                {
                    WriteLine(ex.Message, ConsoleColor.Red);
                }


            }
            Console.ResetColor();
            Console.WriteLine();

        }
        static void ShowAllShapes(List<Shape> shapes)
        {
            Console.WriteLine(new String('-', 50));
            foreach (Shape shape in shapes)
            {
                Console.WriteLine(shape);
            }
        }
        static void LargestPerimeter(List<Shape> shapes)
        {

            Console.WriteLine(new String('-', 50));

            Shape largePerimetr = shapes[0];
            for (int i = 1; i < shapes.Count; i++)
            {
                if (shapes[i].Perimeter() > largePerimetr.Perimeter())
                {
                    largePerimetr = shapes[i];
                }
            }
            Console.WriteLine($"The largest perimeter is {largePerimetr.Name} = {largePerimetr.Perimeter()}");
        }
        static void Main(string[] args)
        {
            List<Shape> shapes = new List<Shape>();

            //Task1

            AddShapes(shapes);
            ShowAllShapes(shapes);

            //Task2

            LargestPerimeter(shapes);

            //Task3

            shapes.Sort();
            ShowAllShapes(shapes);




        }
    }
}