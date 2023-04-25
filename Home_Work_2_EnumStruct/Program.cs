//using System.ComponentModel.DataAnnotations;
// Task 1 

// змiнна для рахунку к-тi iтереацiй циклу

int count = 1;
// змiнна , яку вводить користувач
float number;

Console.WriteLine("Enter  3 float number :");

do
{
    Console.WriteLine($"\nEnter the {count} number");
    number = float.Parse(Console.ReadLine());
    if (number >= -5 && number <= 5)
    {
        Console.WriteLine($"Your number {number} is in range [-5.5]");
    }
    else
    {
        Console.WriteLine($"Nuber isn't in range [-5.5]");
    }

    count++;

}
while (count <= 3);


// Task 2 

int num1, num2, num3, max, min;

Console.WriteLine($"Enter the 3 Numbers: ");
num1 = int.Parse(Console.ReadLine());
num2 = int.Parse(Console.ReadLine());
num3 = int.Parse(Console.ReadLine());
//вважаємо, що num1 є максимальним числом
max = num1;
//порівнюємо його з num2 та num3
if (num2 > max) { max = num2; }
if (num3 > max) { max = num3; }
Console.WriteLine($"Max number is {max}");
Console.WriteLine(new String('-', 20));
//вважаємо, що num1 є мin числом
min = num1;
min = (min > num2) ? num2 : min;
min = (min > num3) ? num3 : min;
Console.WriteLine($"Min number is {min}");

// Task 3

HTTPEnumeration error1 = HTTPEnumeration.BadRequest;
int errorNymber = (int)error1;
Console.WriteLine($"{errorNymber} is {error1} ");

// Task 4

Dog myDog;
myDog.name = "Messi";
myDog.mark = "Pekingese";
myDog.age = 5;
// перевантаження  ToString:
Console.WriteLine(myDog);
// метод Info:
myDog.Info();

// Additional Task 1 

Cat cat = new Cat();
cat.FullnessLevel = 0;
cat.EatSomething(FoodEnum.fisch);
cat.EatSomething(FoodEnum.mouse);
cat.EatSomething(FoodEnum.meat);
cat.EatSomething(FoodEnum.meat);
cat.EatSomething(FoodEnum.meat);

if (cat.FullnessLevel <= 100)
{
    Console.WriteLine(cat.FullnessLevel);
}
else
    Console.WriteLine("I'm full");

// Additional Task 2

Student[] students = new Student[3];

// Заповнюємо масив з даними про студентів
for (int i = 0; i < students.Length; i++)
{
    Console.WriteLine($"Enter the {i + 1} students Last Name: ");
    students[i].name = Console.ReadLine();
    Console.WriteLine($"Enter the {i + 1} students group number: ");
    students[i].group = int.Parse(Console.ReadLine());

}// Виводимо імена студентів заданої групи, які починаються з заданої літери

Console.WriteLine("Enter the group number: ");
int groupNumber = int.Parse(Console.ReadLine());
Console.WriteLine("Enter the first letter of last name:");
char firstLetter = Console.ReadLine()[0];


Console.WriteLine($"Students in group {groupNumber} with last name starting with '{firstLetter}':");
foreach (Student student in students)
{
    if (student.group == groupNumber && student.name[0] == firstLetter)

        Console.WriteLine(student);
}