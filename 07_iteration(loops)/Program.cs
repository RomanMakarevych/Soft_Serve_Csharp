// ------------------------- Iteration Statements -----------------
// while,do while ,for

// while (condition) {... do iteration ..};

//Console.WriteLine( "How mach many do you have: " );
//Console.WriteLine("Enter a value (UAH): ");
//decimal money=decimal.Parse( Console.ReadLine() );

//while (money >= 100 )
//{
//    Console.WriteLine("You can buy a product by 100 UAH!");
//    money -= 100;
//    Console.WriteLine($"Now you have: {money} UAH...");
//}

//-------------- do{..code..} while{condition}
//int age = 0;
//do
//{
//    Console.WriteLine("Enter your age: ");
//    age = int.Parse(Console.ReadLine());
//}

//while (age < 0 || age > 120);

//Console.WriteLine("Continue...");

////----------------- while --------------
//while (age < 0 || age > 120) 
//{
//    Console.WriteLine("Entered age is  incorrect!");
//    Console.WriteLine("Enter your age");
//    age = int.Parse(Console.ReadLine());
//}
//Console.WriteLine("Continue...");

//----------------- break - go out of this statrmrnt
//----------------- continue - skip current loop iteration


//int count = 0;

//while (count < 10)
//{

//    Console.WriteLine($" {count} Iteration ...");
//    ++count;
//    if (count % 3 == 0) break;

//}


//------------- for(initialize;codition;expression){..code..};


//for (int c = 0; c < 10; c++)
//{
//    Console.WriteLine($"[{c}] Iteration");
//}


// Task show numbers in the range except even by 3

//for (int i = 1; i < 20; i++)
//{

//    if (i % 10 == 0) break;
//    if (i % 3 == 0) continue;
//    Console.WriteLine($"Number: {i}");
//}
