using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Home_Work_9
{
    internal class Program
    {
        static int count = 1;
        static void Main(string[] args)
        {
            //Task A_1: Create a list of Shape and fill it with 6 different shapes

            List<Shape> shapes = new List<Shape>()
            {
                new Circle("CirclA1",1),
                new Circle("Circle2",10),
                new Circle("Circle3",4),
                new Square("SquAre1",2),
                new Square("Square2",1),
                new Square("SquAre3",8),

            };
            //Task A_2: Find and write into the file shapes with area from range [10, 100]

            string fileName = "shapesInfo.txt";
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), fileName);
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }

            var shapesInRange = shapes.Where(shape =>
            {
                if (shape is Circle circle)
                {
                    double area = circle.Area();
                    return area >= 10 && area <= 100;
                }
                else if (shape is Square square)
                {
                    double area = square.Area();
                    return area >= 10 && area <= 100;
                }
                return false;
            });

            // write to File shapes with area in range [10,100]
            WriteShapeToFile(filePath, shapesInRange);

            // Task A_3: Find and write into the file shapes which name contains letter 'a'

            var containsLetter = shapes.FindAll(shape => shape.Name.Contains("A"));
            WriteShapeToFile(filePath, containsLetter);

            // Task A_4: Find and remove from the list all shapes with perimeter less than 10

            shapes.RemoveAll(shape => shape.Perimeter() < 10);
            ShowList(shapes);

        }
        static void ShowList(IEnumerable<Shape> shapes)
        {

            foreach (var shape in shapes)
            {
                Console.WriteLine(shape);
            }
        }
        static void WriteShapeToFile(string path, IEnumerable<Shape> shapes)
        {
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine($"Task A_{count}");

                foreach (var shape in shapes)
                {
                    writer.WriteLine(shape);
                }
                ++count;
                writer.WriteLine(new String('-', 80));
            }
        }

    }

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
        public int Radius { get; set; }
        public Circle(string name, int radius) : base(name)
        {
            this.Radius = radius;
        }
        public override double Area()
        {
            return Math.Round((Math.PI * Math.Pow(Radius, 2)), 2);
        }
        public override double Perimeter()
        {
            return Math.Round((2 * Math.PI * Radius), 2);
        }
    }
    class Square : Shape
    {
        public int Side { get; set; }
        public Square(string name, int side) : base(name)
        {
            this.Side = side;
        }
        public override double Area()
        {
            double area = Math.Pow(Side, 2);
            return area;
        }
        public override double Perimeter()
        {
            double perimeter = 4 * Side;
            return perimeter;
        }
    }


}