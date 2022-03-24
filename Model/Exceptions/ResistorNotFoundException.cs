using System;

namespace Model.Exceptions
{
    public class ResistorNotFoundException : Exception
    {
        public ResistorNotFoundException(string Id) : base($"Resistor with id {Id} not found")
        {
        }
    }
}
