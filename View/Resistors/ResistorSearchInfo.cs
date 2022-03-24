using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace View.Resistors
{
    [DataContract]
    public class ResistorSearchInfo
    {
        [DataMember]
        public double? Resistance { get; set; }

        [DataMember]
        public double? MaxAccuracy { get; set; }

        [DataMember]
        public double? MinPower { get; set; }

        [DataMember]
        public int? MinQuantity { get; set; }

        [DataMember]
        public string Material { get; set; }

        [DataMember]
        public string Manufacturer { get; set; }

        [DataMember]
        public int? Limit { get; set; } = 20;

        [DataMember]
        public int? Offset { get; set; } = 0;
    }
}
