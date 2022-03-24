using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Model.Resistors
{
    [DataContract]
    public class ResistorUpdateInfo
    {
        [DataMember]
        [Range(0, 1e8, ErrorMessage = "Value must be positive and less 1e8")]
        public double? Resistance { get; set; }

        [DataMember]
        [Range(0, 1, ErrorMessage = "Accuracy nust be positive and less than 1")]
        public double? Accuracy { get; set; }

        [DataMember]
        [Range(0, 10000, ErrorMessage = "Power must be positive and less 10k")]
        public double? Power { get; set; }

        [DataMember]
        [Range(0, 1e6, ErrorMessage = "Quantity must be positive and less than 1 million")]
        public int? Quantity { get; set; }

        [DataMember]
        [StringLength(20, ErrorMessage = "Maximum string length for material is 20")]
        public string Material { get; set; }

        [DataMember]
        [StringLength(40, ErrorMessage = "Maximum string length for material is 40")]
        public string Manufacturer { get; set; }
    }
}
