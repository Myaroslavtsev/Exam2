using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View.Resistors
{
    public sealed class Resistor
    {
        public double Resistance { get; set; }

        public double Accuracy { get; set; }

        public double Power { get; set; }

        public int Quantity { get; set; }
    }
}
