using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View.Resistors
{
    public class ResistorUpdateInfo
    {
        public double? Resistance { get; set; }

        public double? Accuracy { get; set; }

        public double? Power { get; set; }

        public int? Quantity { get; set; }

        public string Material { get; set; }

        public string Manufacturer { get; set; }
    }
}
