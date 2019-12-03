namespace PlayersAndMonsters.Core
{
    using System;
    using PlayersAndMonsters.Core.Contracts;
    
    public class Engine : IEngine
    {
        private IManagerController manager;

        public Engine()
        {
            this.manager = new ManagerController();
        }

        public void Run()
        {
            string input = Console.ReadLine();

            while (input != "Exit")
            {
                string[] commandParts = input.Split(" ");
                string command = commandParts[0];

                try
                {
                    if (command == "AddPlayer")
                    {
                        string type = commandParts[1];
                        string username = commandParts[2];

                        Console.WriteLine(this.manager.AddPlayer(type, username));
                    }
                    else if (command == "AddCard")
                    {
                        string type = commandParts[1];
                        string name = commandParts[2];

                        Console.WriteLine(this.manager.AddCard(type, name));
                    }
                    else if (command == "AddPlayerCard")
                    {
                        string username = commandParts[1];
                        string cardName = commandParts[2];

                        Console.WriteLine(this.manager.AddPlayerCard(username, cardName));
                    }
                    else if (command == "Fight")
                    {
                        string attacker = commandParts[1];
                        string enemy = commandParts[2];

                        Console.WriteLine(this.manager.Fight(attacker, enemy));
                    }
                    else if (command == "Report")
                    {
                        Console.WriteLine(this.manager.Report());
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                input = Console.ReadLine();
            }
        }
    }
}
