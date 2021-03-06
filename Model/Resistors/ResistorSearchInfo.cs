using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Resistors
{
    public class ResistorSearchInfo
    {
        public double? Resistance { get; set; }

        public double? MaxAccuracy { get; set; }

        public double? MinPower { get; set; }

        public int? MinQuantity { get; set; }

        public string Material { get; set; }

        public string Manufacturer { get; set; }

        public int? Limit { get; set; }

        public int? Offset { get; set; }
    }
}
