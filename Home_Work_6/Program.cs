namespace Home_Work_6
{
    internal class Program
    {
        static int Div(int a, int b)
        {
            return a / b;
        }

        static int ReadNumber(int start, int end)
        {



            Console.WriteLine("Enter the value: ");
            int number = int.Parse(Console.ReadLine());


            if (number < start || number > end)
            {
                throw new ArgumentException($" The number should be between {start} and {end}.");
            }

            return number;
        }

        static void Main(string[] args)
        {
            // Task 1:
            try
            {
                Console.WriteLine("Enter the first value: ");
                int a = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the second value: ");
                int b = int.Parse(Console.ReadLine());

                Console.ForegroundColor = ConsoleColor.Green;
                int res = Div(a, b);
                Console.WriteLine($"{a} / {b} = {res}");
                Console.ResetColor();
            }
            catch (DivideByZeroException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Cannot divide by zero: {ex.Message}");
                Console.ResetColor();
            }

            // Task 2:

            catch (FormatException ex)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"It's not correct format by value: {ex.Message}");
                Console.ResetColor();
            }


            // Task 3:


            Console.WriteLine("Enter the start of range: ");
            int start = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the end of range: ");
            int end = int.Parse(Console.ReadLine());

            //створюемо масив з 10 елементiв
            int[] numbers = new int[10];

            for (int i = 0; i < numbers.Length; i++)
            {
                try
                {
                    numbers[i] = ReadNumber(start, end);


                    if (i > 0 && numbers[i] <= numbers[i - 1]) // перевiряемо чи поточне число бiльше за попередне
                    {
                        throw new ArgumentException("The number should be greater than the previous number entered.");

                    }
                }
                catch (ArgumentException ex)
                {

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{ex.Message}");
                    Console.ResetColor();
                    --i;
                }
                catch (FormatException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"it's not  correct format by value: {ex.Message}");
                    Console.ResetColor();
                    --i;
                }
            }

            Console.WriteLine("You have entered the following numbers:");
            Console.WriteLine(String.Join('\t', numbers));

        }
    }
}