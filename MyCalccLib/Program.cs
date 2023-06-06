namespace MyCalccLib
{
    public class MyCalc
    {
        public int x, y;


        public int Sum(int x, int y)
        {
            return x + y;
        }
        public int Sub(int x, int y)
        {
            return x - y;
        }
        public int Div(int x, int y)
        {
            return x / y;
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            MyCalc calc = new();
            Console.WriteLine(calc.Div(10, 5));

        }
    }
}