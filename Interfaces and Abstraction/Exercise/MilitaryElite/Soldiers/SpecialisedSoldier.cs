namespace MilitaryElite.Soldiers
{
    using System;
    using SoldierInterfaces;

    public class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        private string corps;

        public SpecialisedSoldier(string id, string firstName, string lastName, decimal salary, string corps) 
            : base(id, firstName, lastName, salary)
        {
            this.Corps = corps;
        }

        public string Corps
        {
            get => this.corps;
            protected set
            {
                switch (value)
                {
                    case "Airforces":
                        this.corps = value;
                        break;
                    case "Marines":
                        this.corps = value;
                        break;
                    default:
                        throw new ArgumentException("Invalid corps");
                }
            }
        }
    }
}
