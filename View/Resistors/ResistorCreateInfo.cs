using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace View.Resistors
{
    [DataContract]
    class ResistorCreateInfo
    {
        [DataMember(IsRequired = true)]
        [Range(0, 1e8, ErrorMessage = "Value must be positive and less 1e8")]
        public double Value { get; set; }

        [DataMember]
        [Range(0, 1, ErrorMessage = "Accuracy nust be positive and less than 1")]
        public double Accuracy { get; set; }

        [DataMember(IsRequired = true)]
        [Range(0, 10000, ErrorMessage = "Power must be positive and less 10k")]
        public double Power { get; set; }

        [DataMember]
        [Range(0, 1e6, ErrorMessage = "Quantity must be positive and less than 1 million")]
        public int Quantity { get; set; }

        [DataMember]
        [MaxLength(20, ErrorMessage = "The field Material must be an array type with a maximum length of 20'.")]
        public string Material { get; set; }

        [DataMember]
        [MaxLength(40, ErrorMessage = "The field Manufacturer must be an array type with a maximum length of 40.")]
        public string Manufacturer { get; set; }
    }
}
