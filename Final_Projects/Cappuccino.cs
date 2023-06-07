using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Projects
{
    class Cappuccino : HotBeverage
    {
        public double QuantityOfCappuccino { get; set; }

        public override void Prepare()
        {
            Console.WriteLine($" Cappuccino is preparing... ");
        }
        public override string ToString()
        {
            return $"{Name} - {Price} UAH (Sugar - {SugarLevel}) ";
        }
    }
}
