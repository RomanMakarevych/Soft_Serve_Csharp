

using System;

class Program
{
    static int ReadNumber(int start, int end)
    {
        Console.Write($"Enter a number between {start} and {end}: ");
        int number;
        bool isNumber = int.TryParse(Console.ReadLine(), out number);
        if (!isNumber || number < start || number > end)
        {
            throw new ArgumentException($"The number should be between {start} and {end}.");
        }
        return number;
    }

    static void Main()
    {
        int[] numbers = new int[10];
        int start = 1;
        int end = 10;
        for (int i = 0; i < 5; i++)
        {
            try
            {
                numbers[i] = ReadNumber(start, end);
                if (i > 0 && numbers[i] <= numbers[i - 1])
                {
                    throw new ArgumentException("The number should be greater than the previous number entered.");
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                i--; // Try again with the same index
            }
        }
        Console.WriteLine("You have entered the following numbers:");
        Console.WriteLine(string.Join(", ", numbers));
    }
}
