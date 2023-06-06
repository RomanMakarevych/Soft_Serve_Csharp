using System.ComponentModel;

namespace Home_Work_10_1
{
    public struct Point
    {
        public int x, y;
        public Point(int x, int y) { this.x = x; this.y = y; }

        public override string ToString()
        {
            return $"({x},{y}) ";
        }
    }
    public class Triangle
    {
        public Point vertex1, vertex2, vertex3;
      
        public Triangle(Point vertex1, Point vertex2, Point vertex3)
        {
            this.vertex1 = vertex1;
            this.vertex2 = vertex2;
            this.vertex3 = vertex3;
        }

        public double Distance(Point p1, Point p2)
        {
            int dx = p2.x - p1.x;
            int dy = p2.y - p1.y;
            return Math.Round(Math.Sqrt(dx * dx + dy * dy), 2);
        }

        public double Perimeter()
        {
            double side1 = Distance(vertex1, vertex2);
            double side2 = Distance(vertex2, vertex3);
            double side3 = Distance(vertex3, vertex1);
            return Math.Round((side1 + side2 + side3), 2);
        }

        public double Square()
        {
            double side1 = Distance(vertex1, vertex2);
            double side2 = Distance(vertex2, vertex3);
            double side3 = Distance(vertex3, vertex1);
            double semiperimeter = Perimeter() / 2;
            return Math.Round(Math.Sqrt(semiperimeter * (semiperimeter - side1) * (semiperimeter - side2) * (semiperimeter - side3)), 2);
        }

        public void Print()
        {
            Console.WriteLine($" Triangle with vertices:");
            Console.WriteLine($" Vertex 1: {vertex1}");
            Console.WriteLine($" Vertex 2: {vertex2}");
            Console.WriteLine($" Vertex 3: {vertex3}");
            Console.WriteLine($" Perimeter: {Perimeter()}");
            Console.WriteLine($" Square: {Square()}");
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Triangle> triangles = new List<Triangle>
            {
                new Triangle(new Point(2,1),new Point(1,2),new Point(5,6)),
                new Triangle(new Point(1,1),new Point(3,3),new Point(4,4)),
                new Triangle(new Point(5,6),new Point(6,1),new Point(5,9))
            };
            Console.WriteLine("---------------- Triangle information ----------------\n");

            Show(triangles);

            // Find the triangle with the vertex closest to the origin (0,0)
            ClosestTriangleToOrigin(triangles);


        }

        static void Show(List<Triangle> triangles)
        {
            foreach (Triangle triangle in triangles)
            {
                triangle.Print();
                Console.WriteLine();
            }
        }
        static void ClosestTriangleToOrigin(List<Triangle> triangles)
        {
            Triangle closestTriangle = null;
            double closestDistance = double.MaxValue;

            foreach (Triangle triangle in triangles)
            {
                double distance = triangle.Distance(triangle.vertex1, new Point { x = 0, y = 0 });
                if (distance < closestDistance)
                {
                    closestTriangle = triangle;
                    closestDistance = distance;
                }
            }

            Console.WriteLine("Triangle with vertex closest to origin:");
            closestTriangle?.Print();
           
        }
    }
}