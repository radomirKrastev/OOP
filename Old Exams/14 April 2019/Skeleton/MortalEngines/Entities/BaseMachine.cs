namespace MortalEngines.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Contracts;

    public abstract class BaseMachine : IMachine
    {
        private string name;
        private IPilot pilot;

        public BaseMachine(string name, double attackPoints, double defencePoints, double healthPoints)
        {
            this.Name = name;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defencePoints;
            this.HealthPoints = healthPoints;
            this.Targets = new List<string>();
        }

        public string Name
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Machine name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public IPilot Pilot 
        {
            get => this.pilot;

            set 
            {
                if (value == null)
                {
                    throw new NullReferenceException("Pilot cannot be null.");
                }

                this.pilot = value;
            }
        }

        public double HealthPoints { get; set; }

        public double AttackPoints { get; protected set; }

        public double DefensePoints { get; protected set; }

        public IList<string> Targets { get; private set; }

        public void Attack(IMachine target)
        {
            if (target == null)
            {
                throw new NullReferenceException("Target cannot be null");
            }          

            double attackDamage = this.AttackPoints - target.DefensePoints;

            if (target.HealthPoints - attackDamage < 0)
            {
                target.HealthPoints = 0;
            }
            else
            {
                target.HealthPoints -= attackDamage;
            }            

            this.Targets.Add(target.Name);
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine($"- {this.Name}");
            output.AppendLine($" *Type: {this.GetType().Name}");
            output.AppendLine($" *Health: {this.HealthPoints:F2}");
            output.AppendLine($" *Attack: {this.AttackPoints:F2}");
            output.AppendLine($" *Defense: {this.DefensePoints:F2}");
            output.Append(" *Targets: ");

            if (this.Targets.Count == 0)
            {
                output.AppendLine("None");
            }
            else
            {
                output.Append(string.Join(",", this.Targets));
            }

            return output.ToString().TrimEnd();
        }
    }
}
