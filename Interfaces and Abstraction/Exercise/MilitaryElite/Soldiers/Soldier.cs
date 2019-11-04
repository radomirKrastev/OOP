namespace MilitaryElite.Soldiers
{
    using SoldierInterfaces;

    public abstract class Soldier : ISoldier
    {
        private string id;
        private string firstName;
        private string lastName;

        public Soldier(string id, string firstName, string lastName)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public string Id => this.id;

        public string FirstName => this.firstName;

        public string LastName => this.lastName;
    }
}