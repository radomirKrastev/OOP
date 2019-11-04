namespace MilitaryElite
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using MilitaryElite.Soldiers;

    public class Program
    {
        public static void Main()
        {
            var command = Console.ReadLine();
            var privates = new List<Private>();

            while (command != "End")
            {
                try
                {
                    var commandParts = command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();
                    var soldier = commandParts[0];
                    var id = commandParts[1];
                    var firstName = commandParts[2];
                    var lastName = commandParts[3];

                    if (soldier == "Spy")
                    {
                        var codeNumber = int.Parse(commandParts[4]);

                        var spy = new Spy(id, firstName, lastName, codeNumber);

                        Console.WriteLine(spy.ToString());

                        command = Console.ReadLine();
                        continue;
                    }

                    var salary = decimal.Parse(commandParts[4]);

                    if (soldier == "Private")
                    {
                        var privateSoldier = new Private(id, firstName, lastName, salary);
                        privates.Add(privateSoldier);

                        Console.WriteLine(privateSoldier.ToString());
                    }
                    else if (soldier == "LieutenantGeneral")
                    {
                        var lieutenantGeneral = CreateLieutenant(id, firstName, lastName, salary, privates, commandParts);

                        Console.WriteLine(lieutenantGeneral.ToString());
                    }
                    else if (soldier == "Engineer")
                    {
                        var corps = commandParts[5];

                        var engineer = CreateEngineer(id, firstName, lastName, salary, corps, commandParts);

                        Console.WriteLine(engineer.ToString());
                    }
                    else if (soldier == "Commando")
                    {
                        var corps = commandParts[5];

                        var commando = CreateCommando(id, firstName, lastName, salary, corps, commandParts);

                        Console.WriteLine(commando.ToString());
                    }
                }
                catch
                {
                }

                command = Console.ReadLine();
            }
        }

        private static LieutenantGeneral CreateLieutenant(
            string id,
            string firstName,
            string lastName,
            decimal salary,
            List<Private> privates,
            List<string> commandParts)
        {
            var lieutenantGeneral = new LieutenantGeneral(id, firstName, lastName, salary);

            foreach (var privateId in commandParts.Skip(5))
            {
                var privateSoldier = privates.Where(x => x.Id == privateId).FirstOrDefault();

                lieutenantGeneral?.AddPrivate(privateSoldier);
            }

            return lieutenantGeneral;
        }

        private static Engineer CreateEngineer(
            string id,
            string firstName,
            string lastName,
            decimal salary,
            string corps,
            List<string> commandParts)
        {
            var engineer = new Engineer(id, firstName, lastName, salary, corps);

            for (int i = 6; i < commandParts.Count - 1; i += 2)
            {
                try
                {
                    var repairName = commandParts[i];
                    var repairHours = int.Parse(commandParts[i + 1]);

                    engineer.AddRepair(new Repair(repairName, repairHours));
                }
                catch
                {
                    continue;
                }
            }

            return engineer;
        }

        private static Commando CreateCommando(
            string id, 
            string firstName, 
            string lastName, 
            decimal salary, 
            string corps, 
            List<string> commandParts)
        {
            var commando = new Commando(id, firstName, lastName, salary, corps);

            for (int i = 6; i < commandParts.Count - 1; i += 2)
            {
                try
                {
                    var missionName = commandParts[i];
                    var missionState = commandParts[i + 1];

                    commando.AddMission(new Mission(missionName, missionState));
                }
                catch (ArgumentException)
                {
                    continue;
                }
            }

            return commando;
        }
    }
}
