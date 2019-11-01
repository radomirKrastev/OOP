namespace BorderControl
{
    using System;

    public class Pet : IBirthable
    {
        private string name;
        private DateTime birthDate;

        public Pet(string name, DateTime birthDate)
        {
            this.name = name;
            this.birthDate = birthDate;
        }

        public DateTime BirthDate => this.birthDate;
    }
}
