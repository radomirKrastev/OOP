namespace MortalEngines.Entities
{
    using System.Text;
    using Contracts;    

    public class Tank : BaseMachine, ITank
    {
        private const double InitialHealthPoints = 100;
        private bool defenceMode = true;

        public Tank(string name, double attackPoints, double defencePoints) 
            : base(name, attackPoints, defencePoints, InitialHealthPoints)
        {
            this.AdjustStatsDependingOnDefenceMode();
        }

        public bool DefenseMode => this.defenceMode;

        public void ToggleDefenseMode()
        {
            if (this.DefenseMode)
            {
                this.defenceMode = false;
            }
            else
            {
                this.defenceMode = true;
            }

            this.AdjustStatsDependingOnDefenceMode();
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine(base.ToString());
            string defenceModeStatus = this.DefenseMode ? "ON" : "OFF";
            output.AppendLine($" *Defense: {defenceModeStatus}");

            return output.ToString().TrimEnd();
        }

        private void AdjustStatsDependingOnDefenceMode()
        {
            if (this.DefenseMode)
            {
                this.AttackPoints -= 40;
                this.DefensePoints += 30;
            }
            else
            {
                this.DefensePoints -= 30;
                this.AttackPoints += 40;
            }
        }
    }
}
