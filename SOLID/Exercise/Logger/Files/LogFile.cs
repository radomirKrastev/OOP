namespace Logger.Files
{
    using System;
    using System.Linq;
    using System.Text;        
    using Contracts;    

    public class LogFile : IFile
    {
        private string text;

        public int Size => this.GetSize();

        public void Write(string message)
        {
            var writer = new StringBuilder();

            writer.AppendLine(message);

            this.text += writer.ToString().TrimEnd();
        }
        
        private int GetSize()
        {
            return this.text.Where(x => char.IsLetter(x)).ToArray().Select(x => (int)x).Sum();
        }
    }
}