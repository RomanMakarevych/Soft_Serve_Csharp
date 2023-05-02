// Home Work 4 

Console.ForegroundColor = ConsoleColor.Red;
Person[] persons = new Person[6]
{

    new Person("Roman", new DateTime(1994,01,02)),
    new Person("Oleh" , new DateTime( 1992,02,01)),
    new Person("Roman", new DateTime(2009,12,01)),
    new Person("Igor" , new DateTime(2011,09,22)),
    new Person("Oleh" , new DateTime(2003,06,28)),
    new Person("Artur", new DateTime(2005,05,05)),

};

foreach (Person person in persons)
{
    Console.WriteLine(person);
}
Console.ResetColor();
Console.WriteLine(new String('-', 40));

Console.ForegroundColor = ConsoleColor.Blue;
for (int i = 0; i < persons.Length; i++)
{
    Console.WriteLine($"{persons[i].Name} : {persons[i].Age()} ");
}
Console.ResetColor();
Console.WriteLine(new String('-', 40));
Console.ForegroundColor = ConsoleColor.Green;
for (int i = 0; i < persons.Length; i++)
{
    if (persons[i].Age() < 16)
        persons[i].ChangeName("Very Young!");
    Console.WriteLine($"{persons[i].Name}");
}
Console.ResetColor();
Console.WriteLine(new String('-', 40));
Console.ForegroundColor = ConsoleColor.Yellow;

Console.WriteLine("Enter the name to find ob name is in array: ");
string searchName=Console.ReadLine();

for (int i = 0; i < persons.Length; i++)
{
        if (persons[i].Name == searchName)
            Console.WriteLine($"The same name of array is found:{persons[i]}");
        else
            Console.WriteLine("Not found");
   
}
Console.ResetColor();



