using System;

namespace GLMSCrm.Fakes.Exceptions
{
    public class IncorrectInputValueException : Exception
    {
        public IncorrectInputValueException()
                : base() { }

        public IncorrectInputValueException(string message)
                : base(message) { }

        public IncorrectInputValueException(string message, Exception innerException)
                : base(message, innerException) { }
    
    }
}
