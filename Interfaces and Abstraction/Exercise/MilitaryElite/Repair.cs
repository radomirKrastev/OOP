namespace MilitaryElite
{
    public class Repair
    {
        private string partName;
        private int hours;

        public Repair(string name, int hours)
        {
            this.partName = name;
            this.hours = hours;
        }

        public string PartName => this.partName;

        public int Hours => this.hours;

        public override string ToString()
        {
            return $"Part Name: {this.PartName} Hours Worked: {this.Hours}";
        }
    }
}
