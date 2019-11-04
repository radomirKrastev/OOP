namespace MilitaryElite.Soldiers
{
    using System.Collections.Generic;
    using System.Text;
    using SoldierInterfaces;

    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private HashSet<Private> privates;

        public LieutenantGeneral(string id, string firstName, string lastName, decimal salary) 
            : base(id, firstName, lastName, salary)
        {
            this.privates = new HashSet<Private>();
        }

        public IReadOnlyCollection<Private> Privates => this.privates;

        public void AddPrivate(Private @private)
        {
            this.privates.Add(@private);
        }

        public override string ToString()
        {
            var output = new StringBuilder();

            output.AppendLine(base.ToString());
            output.AppendLine("Privates:");

            foreach (var privateSoldier in this.Privates)
            {
                output.AppendLine($"  {privateSoldier.ToString()}");
            }

            return output.ToString().TrimEnd();
        }
    }
}
