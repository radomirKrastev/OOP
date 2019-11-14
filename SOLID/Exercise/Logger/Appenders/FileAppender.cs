namespace Logger.Appenders
{
    using System;
    using System.IO;
    using Enum;
    using Files.Contracts;
    using Layouts.Contracts;    

    public class FileAppender : Appender
    {
        private IFile file;

        public FileAppender(ILayout layout) 
        {
            this.Layout = layout;
        }

        public FileAppender(ILayout layout, IFile file) : this(layout)
        {
            this.file = file;
        }

        public override string Format => "Appender type: {0}," +
            " Layout type: {1}," +
            " Report level: {2}," +
            " Messages appended: {3}," +
            " File size " + this.file.Size;

        public override ReportLevel ReportLevel { get; set; }

        public override void Append(string date, ReportLevel errorLevel, string message)
        {
            if (errorLevel >= this.ReportLevel)
            {
                this.MessagesCount++;

                var path = @"..\..\..\";
                var output = string.Format(this.Layout.Format, date, errorLevel, message);

                this.file.Write(output);
                File.AppendAllText(path + "log.txt", output + Environment.NewLine);
            }            
        }
    }
}
