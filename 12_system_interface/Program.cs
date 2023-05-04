using System.Collections;

namespace _12_system_interface
{

    class Player:IComparable<Player> ,ICloneable   
    {

        public string? Name { get; set; }
        public int Number { get; set; }
        public int Goals { get; set; }
        public int Games { get; set; }
        public double Productivity => Math.Round((double)Goals / Games, 1);

        public object Clone()
        {
            // shallow copy - copy value types only
            Player copy=(Player) this.MemberwiseClone();
            //deep copy - copy all referance object
            copy.Name= (string)this.Name?.Clone();


            return copy;
        }

        public int CompareTo(Player? other)
        {
            return this.Productivity.CompareTo(other.Productivity);
        }

        public override string ToString()
        {
            return $"[{Number}]: {Goals}/{Games} - KPD {Productivity} ";
        }
    }

    class Team:IEnumerable
    {
        public string  Name { get; set; }

        Player[] players;
        public Team(string name)
        {
            Name = name;
            var rand = new Random();

            int count = rand.Next(5,10);
            players = new Player[count];


            for (int i = 0; i < players.Length; i++)
            {

                players[i] = new Player()
                {
                    Number = rand.Next(100),
                    Games = rand.Next(20,200),
                    Goals = rand.Next(10,500)

                };

            }

        }

        public IEnumerator GetEnumerator()
        {
           return players.GetEnumerator();
        }

        public void Sort()
        {
            // Array.Sort()- requires IComparable<> interface from array item

            Array.Sort(players);    
        }

    }





    internal class Program
    {
        static void Main(string[] args)
        {

            Team team = new Team("Dream Teem");

            foreach (var item in team)
            {
                Console.WriteLine(item);
            }

            Player player = new Player()
            { Number = 9, Games = 44, Goals = 67 };

            Player copy = (Player)player.Clone();

            Console.WriteLine("Player copy");
            player.Games++;
            Console.WriteLine(player);

        }
    }
}