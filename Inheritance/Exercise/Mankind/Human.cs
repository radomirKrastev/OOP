using System;

namespace Mankind
{
    public class Human
    {
        private string firstName;
        private string lastName;

        public Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName
        {
            get => this.firstName;
            protected set
            {
                if (!char.IsUpper(value[0]))
                {
                    throw new ArgumentException("Expected upper case letter!Argument: firstName");
                }
                else if (value.Length <= 3)
                {
                    throw new ArgumentException("Expected length at least 4 symbols! Argument: firstName");
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get => this.lastName;
            protected set
            {
                if (!char.IsUpper(value[0]))
                {
                    throw new ArgumentException("Expected upper case letter!Argument: lastName");
                }
                else if (value.Length <= 2)
                {
                    throw new ArgumentException("Expected length at least 3 symbols! Argument: firstName");
                }

                this.lastName = value;
            }
        }

        public override string ToString()
        {
            return $"First Name: {this.FirstName} {Environment.NewLine}Last Name: {this.lastName}";                
        }
    }
}
