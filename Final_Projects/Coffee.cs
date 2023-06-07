using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Projects
{
    class Coffee : HotBeverage
    {
        public double QuantityOfCoffee { get; set; }

        public override void Prepare()
        {
            Console.WriteLine($" Coffee is preparing... ");

        }
        public override string ToString()
        {
            return $"{Name} - {Price} UAH (Sugar - {SugarLevel}) ";
        }
    }
}
