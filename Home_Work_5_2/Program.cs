namespace Home_Work_5_2
{

    class Person
    {
        public string? Name { get; set; }   
        public int ID { get; set; }


        public override string ToString()
        {
            return $" Name: {Name},ID: {ID}";
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
           Dictionary<uint,string > dic = new Dictionary<uint, string>();
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
}