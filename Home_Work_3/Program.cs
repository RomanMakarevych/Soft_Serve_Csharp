//Task 1

using System;

int count = 0;

Console.WriteLine("Enter the string: ");

string str = Console.ReadLine();

for (int i = 0; i < str.Length; i++)
{
    if (str[i] == 'a' || str[i] == 'o' || str[i] == 'i' || str[i] == 'e')

        count++;
}
Console.WriteLine($"The counts of characters 'a','o','i','e' are {count}");

//Task 2 

int numberMonth;

Console.WriteLine("Please,enter the number of mounth");
try
{
    numberMonth = int.Parse(Console.ReadLine());
    int countDays = DateTime.DaysInMonth(DateTime.Now.Year, numberMonth);

    Console.WriteLine($"There are {countDays} days in month {numberMonth}.");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

//Task 3

Random rand = new Random();
int sum = 0, mult = 1;
int[] arr = new int[10];

Console.WriteLine("Enter 10 integer numbers: ");

// Var1 заповнення масиву самому:
for (int i = 0; i < arr.Length; i++)
{
    arr[i] = int.Parse(Console.ReadLine());
}

//Var2 заповнення рандомними числами:
for (int i = 0; i < arr.Length; i++)
{
    arr[i] = rand.Next(-5, 30); // генеруємо випадкове число від -5 до 30
}

// вивiд  масиву : 
for (int i = 0; i < arr.Length; i++)
{
    Console.Write(arr[i] + "   ");
}
Console.WriteLine();
Console.WriteLine(new String('-',50));

if (arr[0] >= 0 && arr[1] >= 0 && arr[2] >= 0 && arr[3] >= 0 && arr[4] >= 0)
{
    sum = arr[0] + arr[1] + arr[2] + arr[3] + arr[4];
    Console.WriteLine($"Sum of first 5 positive numbers: {sum}");
}
else
{
   
    for (int i = 5; i < 10; i++)
    {
        mult *= arr[i];
    }
    Console.WriteLine($"Product of last 5 non-positive numbers: {mult}");
}

Console.WriteLine(new String('-',50));






