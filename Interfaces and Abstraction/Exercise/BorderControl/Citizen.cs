namespace BorderControl
{
    using System;

    public class Citizen : Passer, IBirthable
    {
        private string name;
        private int age;
        private string id;
        private DateTime birthDate;

        public Citizen(string name, int age, string id)
        {
            this.name = name;
            this.age = age;
            this.id = id;
        }

        public Citizen(string name, int age, string id, DateTime birthDate)
            : this(name, age, id)
        {
            this.birthDate = birthDate;
        }

        public override string Id => this.id;

        public DateTime BirthDate => this.birthDate;
    }
}
