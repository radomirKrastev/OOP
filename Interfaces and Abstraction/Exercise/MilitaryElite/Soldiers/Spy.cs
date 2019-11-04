namespace MilitaryElite.Soldiers
{
    using System;
    using SoldierInterfaces;

    public class Spy : Soldier, ISpy
    {
        private int codeNumber;

        public Spy(string id, string firstName, string lastName, int codeNumber) 
            : base(id, firstName, lastName)
        {
            this.codeNumber = codeNumber;
        }

        public int CodeNumber => this.codeNumber;

        public override string ToString()
        {
            return $"Name: {this.FirstName} {this.LastName} Id: {this.Id} " +
                $"{Environment.NewLine} Code Number: {this.CodeNumber}";
        }
    }
}
