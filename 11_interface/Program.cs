//Interface - defines public object interface members (methods,properties,indexers,events ) 

// syntax: interface Name { ... members ...}

// realization: class Car: Interface,Interface2 ... 


namespace _11_interface
{

    interface IMovable
    {
        public float Speed { get; set; }
        public void Move();
    }

    // interface inheritance : interface I1 : I2 (наслыдування интерфейсыв)

    internal interface IRunnable : IMovable
    {
        // public by default
       
        public void Run();

    }



    class Tiger: IRunnable
    {
        public float Speed { get; set; }
        public double Weight { get; set; }

        public void Move()
        {
            Console.WriteLine("Tiger move");
        }

        public void Run()
        {
            Console.WriteLine($"Tiger running with {Speed} km/h...");
        }
    }
    class Parrot
    {
        public float FlyingHeight { get; set; }
        public double Weight { get; set; }

        public void Fly()
        {
            Console.WriteLine($"Parrot  flying  up to the  {FlyingHeight} m...");
        }
    }
    class Shark
    {
        public float SwimmingDepth { get; set; }
        public double Weight { get; set; }

        public void Swim()
        {
            Console.WriteLine($"Shark is swimming up to the  {SwimmingDepth} m...");
        }
    }

    class Chicken:IRunnable
    {
        public float FlyingHeight { get; set; }
        public double Weight { get; set; }
        public float Speed { get; set; }
        public void Fly()
        {
            Console.WriteLine($"Chicken  flying  up to the  {FlyingHeight} m...");
        }

        public void Move()
        {
            throw new NotImplementedException();
        }

        public void Run()
        {
            Console.WriteLine($"Chicken running with {Speed} km/h...");
        }
    }

    class Cheetah : IRunnable
    {
        public float Speed { get ; set ; }

        public void Move()
        {
            throw new NotImplementedException();
        }

        public void Run()
        {
            Console.WriteLine($"Cheetah running with {Speed} km/h...");

        }
    }



    internal class Program
    {
        static void RunAnimal(IRunnable runnable)
        {
            Console.WriteLine($"Animal can run up to the speed of {runnable.Speed}");
            runnable.Run();
        }

        static void Main(string[] args)
        {

            Tiger tiger = new Tiger() { Speed = 56, Weight = 65.5 };
            Shark shark = new Shark() { SwimmingDepth = 1890, Weight = 205.5 };
            Parrot parrot = new Parrot() { FlyingHeight = 2000, Weight = 1.5 };
            Chicken chicken = new Chicken() { FlyingHeight = 25, Speed = 33.4F, Weight = 5.5 };


            // ------------ interface references ---------

            IRunnable runnable = tiger;
            runnable = chicken;
            // runnable.Run();

            RunAnimal(tiger);
            RunAnimal(chicken);

            //-------------- array of the interface

            IRunnable[] animal = new IRunnable[]
            {
                chicken,
                tiger
            };

            foreach (var item in animal)
            {
                item.Run();
            }

        }
    }
}