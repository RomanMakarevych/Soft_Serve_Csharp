using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static Final_Projects.Program;

namespace Final_Projects
{ 
    abstract class HotBeverage
    {
        public double QuantityOfCoffee { get; set; }
        public double QuantityOfWater { get; set; }
        public string? Name { get; set; }
        public double Price { get; set; }
        public double SugarLevel { get; set; }
        public Category? Category { get; set; }
        public abstract void Prepare();
    }
}
