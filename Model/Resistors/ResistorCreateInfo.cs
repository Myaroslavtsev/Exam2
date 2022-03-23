namespace Model.Resistors
{
    public sealed class ResistorCreateInfo
    {
        public double Resistance { get; set; }

        public double? Accuracy { get; set; }

        public double Power { get; set; }

        public int? Quantity { get; set; }

        public string Material { get; set; }

        public string Manufacturer { get; set; }
    }
}
