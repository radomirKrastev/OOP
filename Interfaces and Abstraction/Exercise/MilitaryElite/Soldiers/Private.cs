namespace MilitaryElite.Soldiers
{
    using SoldierInterfaces;

    public class Private : Soldier, IPrivate
    {
        private decimal salary;        

        public Private(string id, string firstName, string lastName, decimal salary)
            : base(id, firstName, lastName)
        {
            this.salary = salary;
        }

        public decimal Salary => this.salary;

        public override string ToString()
        {
            return $"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.salary:F2}";
        }
    }
}
