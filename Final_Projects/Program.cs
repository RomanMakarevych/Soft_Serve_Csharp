using System;
using System.Data;
using System.Diagnostics.Metrics;
using System.Text.Json;
//-------------------Автомат гарячих напоїв.
//Створити ієрархію класів для подання гарячих напоїв Автомату(кава, чай, капучіно та ін.)
//Створити програму для роботи Автомату у  режимах адмін та користувач
//У режимі адміна передбачити: 	
//	Завантаження автомату водою, кава, чай, цукор
//	Вивід статистики наявності складових для приготування напоїв
//	Зміна цін на напої
//	Вилучення кешу
//У режимі користувача передбачити:		
//Замовлення напою(+ оплата)


namespace Final_Projects
{   
    public delegate void InfoDel();
    internal class Program
    {
        static bool exit = false;
        static double fullContainerTea = 1000;
        static double fullContainerWater = 10000;
        static double fullContainerCoffee = 5000;
        static double fullContainerSugar = 1000;
        static double fullBankMoney = 10000;
        static void Save(VendingMachine vending)
        {
            string json = JsonSerializer.Serialize(vending);
            File.WriteAllText("data vending.json", json);
        }
        static string Load()
        {
            string jsonResult = File.ReadAllText("data vending.json");
            VendingMachine? vendingResult = JsonSerializer.Deserialize<VendingMachine>(jsonResult);

            return vendingResult?.ToString();

        }
        static void Menu(VendingMachine vending)
        {
            Console.WriteLine("--------------------- Welcome to the Coffee Lab --------------------- \n");
            Console.WriteLine(" 1) Admin Mode ");
            Console.WriteLine(" 2) User Mode ");
            Console.WriteLine(" 0) Exit ");
            Console.WriteLine(" Enter your choice: ");
            try
            {
                int choce = int.Parse(Console.ReadLine());
                switch (choce)
                {
                    case 1:
                        MenuAdmin(vending);
                        break;
                    case 2:
                        MenuUser(vending);
                        break;
                    case 0:
                        Console.WriteLine("Good by!");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void MenuUser(VendingMachine vending)
        {
            while (!exit)
            {
                Console.WriteLine("-------------- User Mode -------------- \n");
                Console.WriteLine("    Select an option: ");
                Console.WriteLine(" 1. Order a beverage");
                Console.WriteLine(" 2. Exit");

                Console.WriteLine(" Enter your choice: ");
                int choce = int.Parse(Console.ReadLine());

                switch (choce)
                {
                    case 1:
                        ShowBvg(vending);
                        Console.WriteLine(" Enter the index of hot Beverage: ");
                        int  index = int.Parse(Console.ReadLine());
                        Console.WriteLine(" Put the money to Vending Machine: ");
                        double amountPaid = double.Parse(Console.ReadLine());
                        try
                        {
                            HotBeverage selectedBeverage = vending.HotBeverages[index];
                            vending.OrderBeverage(selectedBeverage, amountPaid);
                        }
                        catch (Exception ex )
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 2:
                        exit = true;
                        Console.WriteLine(" Exiting...");
                        break;

                    default:
                        Console.WriteLine(" Invalid choice. Please try again.");
                        break;
                }
            }
        }
        static void MenuAdmin(VendingMachine vending)
        {
            string passwordAdmin = "Password123";
            int count = 1; // змiнна для пiдрахунку спроб
            const int allAttempt = 3;//константна змiнна спроб вводу пароля
            do
            {
                Console.WriteLine(" Enter a password to log in: ");
                string password = Console.ReadLine();

                if (password == passwordAdmin)
                {
                    while (!exit)
                    {
                        Console.WriteLine("-------------- Admin Mode -------------- ");
                        Console.WriteLine("     Select an option: ");
                        Console.WriteLine(" 1.Add watter ");
                        Console.WriteLine(" 2.Add coffee ");
                        Console.WriteLine(" 3.Add tea ");
                        Console.WriteLine(" 4.Add susugar ");
                        Console.WriteLine(" 5.Take money ");
                        Console.WriteLine(" 6.Change price ");
                        Console.WriteLine(" 7.Loading all Ingredients ");
                        Console.WriteLine(" 0. Exit");

                        Console.WriteLine(" Enter your choice: ");

                        int choce = int.Parse(Console.ReadLine());
                        switch (choce)
                        {
                            case 1:
                                Console.WriteLine(" You can to add the water to vending Machine.\nPleas enter the ml: ");
                                double water = double.Parse(Console.ReadLine());
                                vending.AddWater(water);
                                break;
                            case 2:
                                Console.WriteLine(" You can to add the coffee to vending Machine.\n Pleas enter the gram: ");
                                double coffee = double.Parse(Console.ReadLine());
                                vending.AddWater(coffee);
                                break;
                            case 3:
                                Console.WriteLine(" You can to add the tea to vending Machine.\n Pleas enter the gram: ");
                                double tea = double.Parse(Console.ReadLine());
                                vending.AddWater(tea);
                                break;
                            case 4:
                                Console.WriteLine(" You can to add the susugar to vending Machine.\n Pleas enter the gram: ");
                                double susugar = double.Parse(Console.ReadLine());
                                vending.AddWater(susugar);
                                break;
                            case 5:
                                vending.EmptyCash();
                                break;
                            case 6:
                                Console.WriteLine(" Write the name of hot beverage to change the Price: ");
                                string searchBvg = Console.ReadLine();
                                Console.WriteLine(" Enter the new price: ");
                                double newPrice = double.Parse(Console.ReadLine());
                                HotBeverage beverage = vending.HotBeverages.FirstOrDefault(b => b.Name == searchBvg);
                                if (beverage != null)
                                {
                                    vending.ChangePrice(beverage, newPrice);
                                }
                                else
                                {
                                    Console.WriteLine(" Hot Beverage is not found.");
                                }
                                break;
                            case 7:
                                vending.LoadIngredients(fullContainerWater, fullContainerCoffee, fullContainerTea, fullContainerSugar, fullBankMoney);
                                break;
                            case 0:
                                Console.WriteLine(" Good by!");
                                exit = true;
                                break;
                            default:
                                Console.WriteLine(" Invalid choice. Please try again.");
                                break;
                        }
                    }
                    exit = true;
                }
                else if (count < 3)
                {
                    Console.WriteLine($" Password is not correct.You have {allAttempt - count} attempt.Try again");
                    count++;
                }
                else
                {
                    Console.WriteLine(" Your account is blocked");
                    break;
                }
            }
            while (count <= 3 && !exit);
        }
        static void ShowBvg(VendingMachine vending)
        {
            for (int i = 0; i < vending.HotBeverages.Count; i++)
            {
                Console.WriteLine(i + " " + vending.HotBeverages[i].Name);
            }
        }

        static void Main(string[] args)
        {
            VendingMachine vending = null;
            if (vending == null)
            {
                Category coffeeCategory = new Category { Name = "Coffee" };
                Category teaCategory = new Category { Name = "Tea" };

                vending = new VendingMachine(fullContainerWater, fullContainerCoffee, fullContainerTea, fullBankMoney,
                                             fullContainerSugar, new List<HotBeverage>
           {
                 new Coffee(){ Name = "Americano", Price = 40.50, SugarLevel = 10,QuantityOfWater = 80,Category=coffeeCategory,QuantityOfCoffee=30},
                 new Coffee(){ Name = "Latte", Price = 40.50, SugarLevel = 10,QuantityOfWater = 100,Category=coffeeCategory,QuantityOfCoffee=20},
                 new Coffee(){ Name = "Espresso", Price = 40.50, SugarLevel = 0,QuantityOfWater = 30,Category=coffeeCategory,QuantityOfCoffee=50},
                 new Tea(){Name = "Green Tea", Price = 30.50, SugarLevel = 10 ,QuantityOfWater = 100,Category=teaCategory,QuantityOfTea=50},
                 new Tea(){Name = "Black Tea", Price = 30.50, SugarLevel = 10 ,QuantityOfWater = 100,Category=teaCategory,QuantityOfTea=50},
                 new Tea(){Name = "White Tea", Price = 30.50, SugarLevel = 10 ,QuantityOfWater = 100,Category=teaCategory, QuantityOfTea = 50},
                 new Cappuccino(){Name = "Cappuccino", Price = 45.60, SugarLevel = 20,QuantityOfWater = 80 }
                            });
            }
            Menu(vending);
            Save(vending);
          

        }
        class VendingMachine
        {
            public List<HotBeverage>? HotBeverages { get; set; }
            public event InfoDel InfoEvent;
            private double water;
            private double coffee;
            private double tea;
            private double cash;
            private double sugar;
            public double Water { get => water; set { water = value; } }
            public double Coffee { get => coffee; set { coffee = value; } }
            public double Tea { get => tea; set { tea = value; } }
            public double Sugar { get => sugar; set { sugar = value; } }
            public double Cash { get => cash; set { cash = value; } }

            public VendingMachine(double water, double coffee, double tea, double cash, double sugar, List<HotBeverage> hotBeverages)
            {
                Water = water;
                Coffee = coffee;
                Tea = tea;
                Cash = cash;
                Sugar = sugar;
                HotBeverages = hotBeverages;
                InfoEvent += StatisticOfWater;
            }
            public void StatisticOfWater()
            {
                if (this.water < 100) Console.WriteLine("\n\n It is necessary to add water!!!!!!!!!!");
                else if(coffee<50) Console.WriteLine("\n\n It is necessary to add coffee!!!!!!!!!!");
                else if(tea<50) Console.WriteLine("\n\n It is necessary to add tea!!!!!!!!!!");
                else
                    Console.WriteLine($"\n\n\nAvailability Ingredient:\n{ PrintIngredientAvailability()}"); 
            }
  
            // методи для поокремого завантаження автомату: водою, кавою, чаем, цукром
            public void AddWater(double water)
            {
                if ((this.water + water) <= fullContainerWater)
                {
                    this.water += water;
                    Console.WriteLine($"Water was added. Now is {this.water} ml ");
                }
                else if ((this.water + water) > fullContainerWater)
                {
                    Console.WriteLine($"Rest of water - {water - (fullContainerWater - this.water)} ml");
                    this.water = fullContainerWater;
                    Console.WriteLine($"Water was added. Now is {this.water} ml ");
                }
                else
                    Console.WriteLine("Error.You didn't add water");
            }
            public void AddCoffee(double coffee)
            {
                if ((this.coffee + coffee) <= fullContainerCoffee)
                {
                    this.coffee += coffee;
                    Console.WriteLine($"Coffee was added. Now is {this.coffee} gram ");
                }
                else if ((this.coffee + coffee) > fullContainerCoffee)
                {
                    Console.WriteLine($"Rest of coffee - {coffee - (fullContainerWater - this.coffee)} gram");
                    this.coffee = fullContainerCoffee;
                    Console.WriteLine($"Coffee was added. Now is {this.coffee} gram ");
                }
                else
                    Console.WriteLine("Error.You didn't add Coffee");
            }
            public void AddTea(double tea)
            {
                if ((this.tea + tea) <= fullContainerTea)
                {
                    this.tea += tea;
                    Console.WriteLine($"Tea was added. Now is {this.tea} gram ");
                }
                else if ((this.tea + tea) > fullContainerTea)
                {
                    Console.WriteLine($"Rest of Tea - {tea - (fullContainerWater - this.tea)} gram");
                    this.coffee = fullContainerTea;
                    Console.WriteLine($"Tea was added. Now is {this.tea} gram ");
                }
                else
                    Console.WriteLine("Error.You didn't add tea");
            }
            public void AddSugar(double sugar)
            {
                if ((this.sugar + sugar) <= fullContainerSugar)
                {
                    this.sugar += sugar;
                    Console.WriteLine($" Sugar was added. Now is {this.sugar} gram ");
                }
                else if ((this.sugar + sugar) > fullContainerSugar)
                {
                    Console.WriteLine($" Rest of sugar - {sugar - (fullContainerWater - this.sugar)} gram");
                    this.sugar = fullContainerSugar;
                    Console.WriteLine($" Sugar was added. Now is {this.sugar} gram ");
                }
                else
                    Console.WriteLine(" Error.You didn't add sugar");
            }

            // метод для завантаження автомату водою, кава, чай, цукор
            public void LoadIngredients(double water, double coffee, double tea, double susugar, double cash)
            {
                this.water += water;
                this.coffee += coffee;
                this.tea += tea;
                this.sugar += susugar;
                this.cash += cash;
            }
            // метод для виводу статистики наявності складових для приготування напоїв
            public string PrintIngredientAvailability()
            {
                return $" Water: {water} ml\n Coffe: {coffee} gram\n Tea: {tea} gram\n Susugar: {sugar} gram\n";

            }
            // метод для змiни цiни на напої
            public void ChangePrice(HotBeverage beverage, double newPrice)
            {
                beverage.Price = newPrice;

            }
            //Вилучення кешу
            public string EmptyCash()
            {
                cash = 0;
                return $"Cash emptied.";
            }
            // метод для замовлення
            public void OrderBeverage( HotBeverage selectedBeverage, double amountPaid)
            {
                if (selectedBeverage != null && HotBeverages.Contains(selectedBeverage))
                {
                    if (amountPaid >= selectedBeverage.Price && this.water >= selectedBeverage.QuantityOfWater)
                    {
                        if (selectedBeverage is Coffee && coffee>=(selectedBeverage as Coffee).QuantityOfCoffee)
                        {
                             Coffee coffeeBvg = selectedBeverage as Coffee;
                             this.coffee -= coffeeBvg.QuantityOfCoffee;                            
                        }
                        else if (selectedBeverage is Tea && tea>=(selectedBeverage as Tea).QuantityOfTea )
                        {
                            Tea taeBvg = selectedBeverage as Tea;
                            this.tea -= taeBvg.QuantityOfTea;
                        }
                        
                        cash += selectedBeverage.Price;
                            selectedBeverage.Prepare();
                            Console.WriteLine($"Prepared {selectedBeverage.Name}.\nThank You");
                            Console.WriteLine($"Change: {amountPaid - selectedBeverage.Price}");
                            this.water -= selectedBeverage.QuantityOfWater;
                            this.sugar -= selectedBeverage.SugarLevel;

                            InfoEvent?.Invoke();                       
                    }
                    else if (amountPaid < selectedBeverage.Price)
                    {
                        Console.WriteLine("Insufficient payment. Please insert more money.");
                    }                 
                }
                else
                {
                    Console.WriteLine("Selected beverage not found.");
                }
                Console.WriteLine();
            }
            
        }
    }
}




