using System.ComponentModel.DataAnnotations;

class Person
{
    private string? name;
    private DateTime birthYear;

    public Person()  
    {
        name = "no set name";
        birthYear = default;   

    }
    public Person(string? name, DateTime birthYear)
    {
        this.name = name;
        this.birthYear = birthYear;
    }

    public string Name
    {
        get { return name; }
    }

    public DateTime BirthYear
    {
        get { return birthYear; }
    }

    public int Age()
    {
        TimeSpan timeSpan = DateTime.Now - birthYear;
        int age=(int)(timeSpan.TotalDays / 365);

        return age;
    }

    public void Input()
    {
        Console.WriteLine("Enter your name: ");
        name = Console.ReadLine();

        Console.Write("Enter birth year (yyyy-MM-dd): ");
        birthYear = DateTime.Parse(Console.ReadLine());
    }

    public void ChangeName(string newName)
    {
        name = newName;
    }


    public override string ToString()
    {

        return $"Name: {Name}, The birthday: {BirthYear.ToShortDateString()} ";

    }

    public void Output()
    {
        Console.WriteLine(ToString());
    }

    public static bool operator ==(Person person1, Person person2)
    {
        return person1.Name == person2.Name;
    }

    public static bool operator !=(Person person1, Person person2)
    {
        return person1.Name != person2.Name;
    }

}

