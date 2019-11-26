using System;

namespace ValidPerson
{
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
                    throw new ArgumentNullException($"{nameof(FirstName)} cannot be null or empty!");
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
                    throw new ArgumentNullException($"{nameof(this.LastName)} cannot be null or empty!");
                }

                this.lastName = value;
            }
        }

        public int Age
        {
            get => this.age;

            private set
            {
                if (value<0||value>120)
                {
                    throw new ArgumentOutOfRangeException($"{nameof(this.Age)} must be between 0 and 120!");
                }

                this.age = value;
            }
        }
    }
}
