using System.Security.Cryptography.X509Certificates;

namespace _10_classes
{

    enum Mode { Dry, Cool, Heat }
    class Conditioner
    {
        // ------------ Fields--------------:
        // default values = 0 , boolean = false, reference = null
        string? model;
        string? color;
        decimal price;
        int currentTemperature;
        int serialNumber;
        // 1 - Dry, 2 - Cool, 3 - Heat
        Mode mode;
        bool isPowerOn;

        //------------- Properties------------------:
        public int Temperature
        {
            get
            {
                return this.currentTemperature;
            }

            set
            {
                if (value >= 16 && value < 32)
                    this.currentTemperature = value;
            }
        }


        //---------------- method------------------
        public Conditioner(): this("no model","no color",0,0) //constructor delegation
        {
        
        }
        public Conditioner(string model,string color,decimal price, int currentTemperature)
        {
            this.model = model;
            this.color = color;
            this.price = price; 
            this.currentTemperature = currentTemperature;
            //this.serialNumber = $"00{new Random().Next(100, 999)}";
        }

        //public void Initilaize()
        //{
        //    model = "no model";
        //    color = "no color";
        //    price = 0;
        //    currentTemperature = 16;
        //    mode= Mode.Cool;
        //    isPowerOn = true;   
        //}


        public void SwitchPower()
        {
            isPowerOn = !isPowerOn;
        }
        public void Increase()
        {

            if(currentTemperature < 32)
            ++this.currentTemperature;

        }
        public void Decrease()
        {
            if (currentTemperature > 16)
                --this.currentTemperature;

        }

        public override string ToString()
        {
            return $"Conditioner: {model},{color},Status:{(isPowerOn ? "On" : "Off")},Mode: {mode}, Temperature: {currentTemperature}";
        }


        public void SetTemperature(int value)
        {

            if(value>=16 && value<32)
            this.currentTemperature = value;

        }
        public int GetTemperature()
        {
            return this.currentTemperature;
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //========== creat instance of the class


            Conditioner conditioner = new Conditioner("Appel","White",10,16);
            Console.WriteLine(conditioner);

            conditioner.Increase();
            Console.WriteLine(conditioner);

            conditioner.SetTemperature(36);
            Console.WriteLine(conditioner);

            conditioner.Temperature = 10;

        }
    }
}