using System;
using System.Collections.Generic;

namespace Task_8
{
    class Person : IComparable<Person>
    {
        private string name;
        public Person(string name)
        {
            this.name = name;
        }

        public  string? Name { get { return name; } }

        public int CompareTo(Person other)
        {
            return this.name.CompareTo(other.name);
        }

        public virtual void Print()
        {
            Console.WriteLine($"Person Name: {name}");
        }
    }

    class Staff : Person
    {
        private int salary;
        public Staff(string name, int salary) : base(name)
        {
            this.salary = salary;
        }

   
        public override void Print()
        {
            base.Print();
            Console.WriteLine($" has salary: {salary}");
        }
    }

    class Teacher : Staff
    {
        private string subject;
        public Teacher(string name, int salary, string subject) : base(name, salary)
        {
            this.subject = subject;
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Subject: {subject}");
        }
    }

    class Developer : Staff
    {
        private int level;
        public Developer(string name, int salary, int level) : base(name, salary)
        {
            this.level = level;
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Level: {level}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();

            persons.Add(new Staff("Petro", 1200));
            persons.Add(new Teacher("Anton", 1000, "Englisch"));
            persons.Add(new Developer("Roman", 5000, 1));

            foreach (Person person in persons)
            {
                person.Print();
            }

            try
            {
                Console.WriteLine("Enter a name:");
                string name = Console.ReadLine();
                bool nameFound = false;

                foreach (Person person in persons)
                {
                    if (person.Name==name)
                    {
                        Console.WriteLine($"The name {name} is in the list of persons");
                        nameFound = true;
                        break;
                    }
                }

                if (!nameFound)
                {
                    Console.WriteLine("The name was not found");
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("It's not in the correct format");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine(new string('-',50));

            persons.Sort();
            foreach (Person person in persons)
            {
                person.Print();
            }

        }
    }
}
