namespace MilitaryElite.Soldiers
{
    using System.Collections.Generic;
    using System.Text;
    using SoldierInterfaces;

    public class Engineer : SpecialisedSoldier, IEngineer
    {
        private HashSet<Repair> repairs;

        public Engineer(
            string id,
            string firstName,
            string lastName,
            decimal salary,
            string corps) 
            : base(id, firstName, lastName, salary, corps)
        {
            this.repairs = new HashSet<Repair>();
        }

        public IReadOnlyCollection<Repair> Repairs => this.repairs;

        public void AddRepair(Repair repair)
        {
            this.repairs.Add(repair);
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendLine(base.ToString());
            output.AppendLine($"Corps: {this.Corps}");
            output.AppendLine($"Repairs:");

            foreach (var repair in this.Repairs)
            {
                output.AppendLine($"  {repair.ToString()}");
            }

            return output.ToString().TrimEnd();
        }
    }
}
