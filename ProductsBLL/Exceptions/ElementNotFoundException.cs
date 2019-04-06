using System;

namespace ProductsBLL.Exceptions
{
    public class ElementNotFoundException : Exception
    {
        public ElementNotFoundException(int id)
            : base($"Element not found with Id {id}")
        {}

        public ElementNotFoundException(string message)
            : base(message)
        {}
    }
}
