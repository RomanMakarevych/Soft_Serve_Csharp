namespace Task_9
{
    internal class Program
    {
        

        static void Main(string[] args)
        {

            int[] arr = new int[10] { 12, 33, -20, 1, 0, 2, 3, 4, -3, 11 };

            var res = arr.Where(x => x < 0);

            var positive = arr.Where(x => x >= 0);


            var largest = arr.Max(x => x);
            Console.WriteLine(largest);
            Console.WriteLine(new String('-', 20));
            var min = arr.Min(x => x);
            Console.WriteLine(min);
            Console.WriteLine(new String('-',20));
            int sum = arr.Sum();
            Console.WriteLine(sum);

            var aver =(int) arr.Average();

            Console.WriteLine(aver);
            var firstMax = arr.Where(x => x > aver);
           
            
            foreach (var item in firstMax)
            {
                Console.WriteLine(item + " ");
            }


            foreach (var item in arr.OrderBy(x => x))
            {
                Console.Write(item+" ");
            } 



        }
    }
}