namespace MilitaryElite.Soldiers
{
    using System.Collections.Generic;
    using System.Text;
    using SoldierInterfaces;

    public class Commando : SpecialisedSoldier, ICommando
    {
        private HashSet<Mission> missions;

        public Commando(string id, string firstName, string lastName, decimal salary, string corps) 
            : base(id, firstName, lastName, salary, corps)
        {
            this.missions = new HashSet<Mission>();
        }

        public IReadOnlyCollection<Mission> Missions => this.missions;

        public void AddMission(Mission mission)
        {
            this.missions.Add(mission);
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendLine(base.ToString());
            output.AppendLine($"Corps: {this.Corps}");
            output.AppendLine($"Missions:");

            foreach (var mission in this.Missions)
            {
                output.AppendLine($"  {mission.ToString()}");
            }

            return output.ToString().TrimEnd();
        }
    }
}
