namespace Home_Work_5
{
    using System.Collections.Generic;
    internal class Program
    {
        static void Main(string[] args)
        {
            // Task 1

            // Creat the List of IDeveloper:


            List<IDeveloper> developers = new List<IDeveloper>();

            Builder b1 = new Builder { Tool = "AutoCAD", BuildingType = "House" };
            developers.Add(b1);
            Builder b2 = new Builder { Tool = "SketchUp", BuildingType = "Office" };
            developers.Add(b2);

            Programmer p1 = new Programmer("C#", "Visual Studio");
            developers.Add(p1);
            Programmer p2 = new Programmer("C++", "Visual Studio");
            developers.Add(p2);
            Programmer p3 = new Programmer("Java", "Eclipse");
            developers.Add(p3);

            foreach (var item in developers)
            {
                Console.WriteLine(item);
            }

            // Sort list of IDeveloper: 

            Console.WriteLine(new String('-', 50));
            developers.Sort();

            foreach (var item in developers)
            {
                Console.WriteLine(item);
            }

            // Call Creat() and Destroy() methods for all of it:


            Console.WriteLine(new String('-', 50));
            Console.ForegroundColor = ConsoleColor.Blue;
           
            foreach(var item in developers)
            {
                item.Create();
            }
            Console.ResetColor();

            Console.WriteLine(new String('-', 50));
            Console.ForegroundColor = ConsoleColor.Yellow;

            foreach (var item in developers)
            {
                item.Destroy();
            }
            Console.ResetColor();



            // Sort list of IDeveloper:


            Console.WriteLine(new String('-', 50));

            DeveloperComparer comparer = new DeveloperComparer();
            developers.Sort(comparer);

            foreach (IDeveloper developer in developers)
            {
                Console.WriteLine(developer.GetType().Name + " using " + developer.Tool);
            }



            // Sort list of Programmer:


            Console.WriteLine(new String('-', 50));

            List<Programmer> programmers = new List<Programmer>();

            Programmer a1 = new Programmer("C#", "Visual Studio");
            programmers.Add(a1);
            Programmer a2 = new Programmer("C++", "Visual Studio");
            programmers.Add(a2);
            Programmer a3 = new Programmer("Java", "Eclipse");
            programmers.Add(a3);

            programmers.Sort();

            foreach (Programmer p in programmers)
            {
                Console.WriteLine(p.GetType().Name + " using " + p.Tool);
            }

            //////////////////////////////////////////////////////////////////
            //Task 2

            Dictionary<uint, string> dic = new Dictionary<uint, string>();
            dic.Add(12345, "Roman");
            dic.Add(23451, "Oleg");
            dic.Add(12456, "Igor");
            dic.Add(77755, "Roman");
            dic.Add(66655, "Petro");
            dic.Add(44455, "Ivan");
            dic.Add(11111, "Pulup");

            Console.WriteLine("Enter the ID to find in dictionary Name: ");
            uint ID = uint.Parse(Console.ReadLine());

            if (dic.ContainsKey(ID))
            {
                string name = dic[ID];
                Console.WriteLine($"The name associated with ID {ID} is {name}.");
            }
            else
            {
                Console.WriteLine($"No name found for ID {ID}.");
            }
        }
    }

   class DeveloperComparer : IComparer<IDeveloper>
    {
        int IComparer<IDeveloper>.Compare(IDeveloper? x, IDeveloper? y)
        {
            return x.Tool.CompareTo(y.Tool);
        }
    }

    class Builder : IDeveloper , IComparable<Builder>
    {
        private string? buildingType;
        public string Tool { get; set; }

        public Builder() : this("no set", "no set") { }
        public Builder(string buildingType,string tool)
        {
            this.buildingType = buildingType;
            this.Tool = tool;
        }

        public string BuildingType
        {
            get { return buildingType; }
            set { buildingType = value; }
        }

        public int CompareTo(Builder? other)
        {

            if (other == null)
            {
                return 1;
            }
            else
            {
                int typeComparison = this.GetType().Name.CompareTo(other.GetType().Name);
                if (typeComparison != 0)
                {
                    return typeComparison;
                }
                else
                {
                    return this.BuildingType.CompareTo(other.BuildingType);
                }
            }
        }

        public void Create()
        {
            Console.WriteLine("Builder Create()"); ;
        }

        public void Destroy()
        {
            Console.WriteLine("Builder Destroy()"); ;
        }

        public override string ToString()
        {
            return $"Tool: {Tool}, Building Type: {buildingType} ";
        }

        public int CompareTo(IDeveloper? other)
        {
            return this.Tool.CompareTo(other.Tool);
        }
    }


    class Programmer : IDeveloper ,IComparable<Programmer>   
    {
        private string? language;
        public string Tool { get; set; }

        public Programmer() : this(null, null) { }
        public Programmer(string language, string tool)
        {
            this.language = language;
            this.Tool = tool;
        }

        public string Language
        {
            get { return language; }
            set { language = value; }
        }


        public void Create()
        {
            Console.WriteLine("Programmer  Create()");
        }

        public void Destroy()
        {
            Console.WriteLine("Programmer  Destroy()");
        }

        public override string ToString()
        {
            return $"Language: {language}, Tool: {Tool}";
        }

        public int CompareTo(Programmer? other)
        {
            if (other == null) return 1;
            return this.Language.CompareTo(other.Language);
        }

        public int CompareTo(IDeveloper? other)
        {
            if (other == null) return 1;

            return this.Tool.CompareTo(other.Tool);
        }
    }

    interface IDeveloper:IComparable<IDeveloper>
    {
        string Tool { get; set; }
        void Create();
        void Destroy();
    }
}