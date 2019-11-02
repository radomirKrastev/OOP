namespace BorderControl
{
    using System;

    public class Citizen : Passer, IBirthable, IBuyer
    {
        private string name;
        private int age;
        private string id;
        private DateTime birthDate;
        private int food;

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

        public int Food => this.food;

        public string Name => this.name;

        public void BuyFood()
        {
            this.food += 10;
        }
    }
}
