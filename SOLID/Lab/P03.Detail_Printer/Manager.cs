namespace P03.DetailPrinter
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Manager : Employee
    {
        public Manager(string name, ICollection<string> documents) : base(name)
        {
            this.Documents = new List<string>(documents);
        }

        public IReadOnlyCollection<string> Documents { get; set; }

        public override string ToString()
        {
            var output = new StringBuilder();

            output.AppendLine(base.ToString());
            output.AppendLine(string.Join(Environment.NewLine, this.Documents));

            return output.ToString().TrimEnd();
        }
    }
}
