using System;
using System.Drawing;

namespace Task4
{
    class Car
    {
        string? name;
        string? color;
        double price;
        const string companyName = "BMW";

        public Car() : this("No set", "No set", 0) { }
        public Car(string name, string color, int Price)
        {
            this.name = name;
            this.color = color;
            this.price = Price;
        }

        public string Color { get; set; }
        public void Input()
        {
            this.name = Console.ReadLine();
            this.color = Console.ReadLine();
            this.price = double.Parse(Console.ReadLine());

        }



        public double ChangePrice(double value)
        {
            return price * value / 100;
        }

        public void Print()
        {
            Console.WriteLine($"Name: {name},Color: {color}, Price: {price}, Company Name:  {companyName}  ");
        }


        public static bool operator ==(Car car1, Car car2)
        {
            return car1.name == car2.name;
        }

        public static bool operator !=(Car car1, Car car2)
        {
            return car1.name != car2.name;
        }
    }

    internal class Program
    {


        static void Main(string[] args)
        {

        }
    }
}