namespace _13_interface_exampl
{

    public class Rectangle
    {

        public int Widht { get; set; }
        public int Height { get; set; }
        
        public int X { get; set; }
        public int Y { get; set; }


        public void Print()
        {

            for (int i = 0; i < Height; i++)
            {
              Console.SetCursorPosition(X, Y+i);
                for (int j = 0; j < Widht; j++)
                {
                    Console.Write('#');
                }
                Console.WriteLine();
            }
        }

    }





    public class Tiangle
    {

      
        public int Height { get; set; }

        public int X { get; set; }
        public int Y { get; set; }


        public void Print()
        {

            for (int i = 0; i < Height; i++)
            {
                Console.SetCursorPosition(X, Y + i);
                for (int j = 0; j <= i; j++)
                {
                    Console.Write('#');
                }
                Console.WriteLine();
            }
        }

    }



    internal class Program
    {
        static void Main(string[] args)
        {
          Rectangle rectangle = new Rectangle()
          {
             Height=6,Widht=20,X=5,Y=5
          };

            Tiangle triangle = new Tiangle()
            {
                Height = 12,
               
                X = 10,
                Y = 10
            };

            rectangle.Print();
            triangle.Print();
        }
    }
}