namespace MortalEngines.Entities.Models
{
    using System.Text;
    using Contracts;

    public class Fighter : BaseMachine, IFighter
    {
        private const double InitialHealthPoints = 200;

        private bool aggressiveMode = true;

        public Fighter(string name, double attackPoints, double defencePoints) 
            : base(name, attackPoints, defencePoints, InitialHealthPoints)
        {
            this.AdjustStatsDependingOnAgression();
        }

        public bool AggressiveMode => this.aggressiveMode;

        public void ToggleAggressiveMode()
        {
            if (this.AggressiveMode)
            {
                this.aggressiveMode = false;
            }
            else
            {
                this.aggressiveMode = true;
            }

            this.AdjustStatsDependingOnAgression();
        }
               
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine(base.ToString());
            string agressionStatus = this.AggressiveMode ? "ON" : "OFF";
            output.AppendLine($" *Aggressive: {agressionStatus}");

            return output.ToString().TrimEnd();
        }

        private void AdjustStatsDependingOnAgression()
        {
            if (this.AggressiveMode)
            {
                this.AttackPoints += 50;
                this.DefensePoints -= 25;
            }
            else
            {
                this.DefensePoints += 25;
                this.AttackPoints -= 50;
            }
        }
    }
}
