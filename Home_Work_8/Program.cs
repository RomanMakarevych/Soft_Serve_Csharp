using System.Collections.Generic;

namespace Home_Work_8
{

    
    abstract class Shape:IComparable<Shape>
    {
        private string? name;
        public string? Name { get; set; }

        public Shape(string name)
        {
            this.name = name;
        }
        public abstract double Area();
        public abstract double Perimeter();

        public override string ToString()
        {
            return $"The Shape: {name} , Area: {Area()} cm^2, Perimeter: {Perimeter()} cm  ";
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
            double area = Math.Round((Math.PI * Math.Pow(radius, 2)),2);

            return area;
        }

        public override double Perimeter()
        {
            double perimeter = Math.Round((2 * Math.PI * radius),2);
            return perimeter;
        }

    }
    class Square : Shape
    {
        private int side;
        public int Side { get; set; }   
        public Square(string name,int side) : base(name)
        {
            this.side = side;
        }

        public override double Area()
        {
            double area = Math.Pow(side,2); 
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
        static void AddShapes(List<Shape> shapes)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\t\tEnter data of 10 diffent shapes.\n");

            for (int i = 0; i < 3;)
            {
                try
                {
                 
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Enter the name of shapes:");
                Console.ForegroundColor = ConsoleColor.Green;
                string? name = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Enter 1 for Circle or 2 for Square: ");
                Console.ForegroundColor = ConsoleColor.Green;
                int shapeType = int.Parse(Console.ReadLine());
                
                    if(shapeType == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Enter the radius: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        int radius = int.Parse(Console.ReadLine());
                        Circle circle = new(name,radius);
                        shapes.Add(circle);
                        i++;
                    }
                    else if(shapeType == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Enter the side: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        int side =int.Parse(Console.ReadLine());    
                        Square square = new(name,side);
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
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input format. Please enter a valid number.");
                }       
                catch (ArgumentException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                }
               

            }
            Console.ResetColor();
            Console.WriteLine();

        }
        static void ShowAllShapes(List<Shape> shapes)
        {
            Console.WriteLine(new String('-',50));
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