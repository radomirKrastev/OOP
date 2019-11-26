namespace ValidPerson
{
    using System;

    public class InvalidPersonNameException : Exception
    {
        public InvalidPersonNameException(string message)
            : base(message)
        {
        }
    }
}
