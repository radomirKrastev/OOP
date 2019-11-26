namespace ValidPerson
{
    using System;
    using System.Linq;
    
    public class Person
    {
        private string firstName;

        private string lastName;

        private int age;

        public Person(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        public string FirstName
        {
            get => this.firstName;

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("First name cannot be null or empty!");
                }

                if (!value.All(char.IsLetter))
                {
                    throw new InvalidPersonNameException("First name contains invalid characters!");
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get => this.lastName;

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Last name cannot be null or empty!");
                }

                if (!value.All(char.IsLetter))
                {
                    throw new InvalidPersonNameException("Last name contains invalid characters!");
                }

                this.lastName = value;
            }
        }

        public int Age
        {
            get => this.age;

            private set
            {
                if (value < 0 || value > 120)
                {
                    throw new ArgumentOutOfRangeException("Age must be between 0 and 120!");
                }

                this.age = value;
            }
        }
    }
}
