namespace StudentSystem.Data
{
    using System;

    public class ConsoleDataWriter : IDataWriter
    {
        public void Write(object obj)
        {
            Console.WriteLine(obj);
        }
    }
}
