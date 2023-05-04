namespace Task_5_1
{
    internal class Program
    {

        interface IFlyable
        {
            public void Fly();
        }

        class Bird : IFlyable
        {
            private string? name;
            private bool canFly;

            public string Name
            {
                get { return name; }
                set { this.name = value; }
            }
            public bool CanFly
            {
                get { return canFly; }
                set { this.canFly = false; }
            }

            public void Fly()
            {
                Console.WriteLine($"Bird with {name}  fly: {canFly}"); ;
            }
        }

        class Plane : IFlyable
        {

            public string? Mark { get; set; }
            public float HighFly { get; set; }

            public void Fly()
            {
                Console.WriteLine($"The Plane {Mark} , fly up to the  {HighFly} km ... ");
            }
        }


        static void Main(string[] args)
        {
            List<IFlyable> flyables = new List<IFlyable>
            {
                new Bird { Name = "Parrot", CanFly = true },
                new Bird { Name = "Chicken", CanFly = true },
                new Bird { Name = "Straus", CanFly = false },
                new Plane { Mark = "AN-56", HighFly = 10000 },
                new Plane { Mark = "AN-53", HighFly = 9000 }


            };

            foreach (var item in flyables)
            {
                item.Fly();
            }

        }
    }
    }
    