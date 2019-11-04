namespace ExplicitInterfaces
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var command = Console.ReadLine();

            while (command != "End")
            {
                var commandParts = command.Split(" ");

                var name = commandParts[0];
                var country = commandParts[1];
                var age = int.Parse(commandParts[2]);

                IPerson person = new Citizen(name, country, age);
                IResident resident = new Citizen(name, country, age);
                
                Console.WriteLine(person.GetName());
                Console.WriteLine(resident.GetName());

                command = Console.ReadLine();
            }
        }
    }
}
