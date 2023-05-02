////--------------trnarny operator: (condition ? value_if_true : value_if_false)
//int number=5;

//Console.WriteLine($"You number is: {(number > 0 ? "Positive":(number < 0 )? "Negative" : "Zero")}");
//int res = (number >= 0 ? number : 0);

////---------------------- if,ifelse,switch

////if(coditon) {... some code..}

//string name =Console.ReadLine();
//if (char.IsUpper(name[0]))
//{
//    Console.WriteLine("Name is correct");

//}
//else
//{
//    Console.ForegroundColor = ConsoleColor.Red;   
//    Console.WriteLine("Name should starts with upper letter!");
//    Console.ResetColor();
//}

//if(name.Length < 3)
//    Console.WriteLine($"Name too short");
//else
//    Console.WriteLine("Name has a goof Lenght");

//using System.Reflection.Metadata.Ecma335;

//Console.WriteLine("Enter  a mark (1-5)");
//int mark = int.Parse(Console.ReadLine());

//if (mark == 5)
//{
//    Console.WriteLine("Excellent!");
//}else if(mark == 4)
//{
//    Console.WriteLine("Good!");
//}else if(mark == 3)
//{
//    Console.WriteLine("Normal!");
//}else if(mark == 2)
//{
//    Console.WriteLine("Bed!");
//}else if(mark == 1)
//{
//    Console.WriteLine("Very Bed!");
//}else
//    Console.WriteLine("Mark is incorrect!");

//  switch(expresion) {case 1 :... break; case2: ... break;}

//switch (mark)
//{
//    case 1:
//        Console.WriteLine("Very Bed!!");
//        break;
//    case 2:
//        Console.WriteLine(" Bed!!");
//        break;
//    case 3:
//        Console.WriteLine("Normal!");
//        break;
//    case 4:
//        Console.WriteLine("Good!");
//        break;
//    case 5:
//        Console.WriteLine("Excellent!");
//        break;
//    default:
//        Console.WriteLine("Mark is incorrect!");
//        break;

//}

// task : enter age,check permisstions
Console.WriteLine("Enter your age: ");
int age=int.Parse(Console.ReadLine());

if (age > 10 && age <= 16)
    Console.WriteLine("You are young boy");
else if(age>16 && age < 50)
    Console.WriteLine("You are adult  man");