namespace MXGP.Core
{
    using System;
    using MXGP.Core.Contracts;    
    using MXGP.IO;

    public class Engine : IEngine
    {
        private IChampionshipController controller;
        private ConsoleReader reader;
        private ConsoleWriter writer;
        
        public Engine()
        {
            this.controller = new ChampionshipController();
            this.reader = new ConsoleReader();
            this.writer = new ConsoleWriter();
        }

        public void Run()
        {
            var input = this.reader.ReadLine();

            while (input != "End")
            {
                var parts = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                var command = parts[0];

                try
                {
                    if (command == "CreateRider")
                    {
                        var name = parts[1];

                        this.writer.WriteLine(this.controller.CreateRider(name));
                    }
                    else if (command == "CreateMotorcycle")
                    {
                        var type = parts[1];
                        var model = parts[2];
                        var horsePower = int.Parse(parts[3]);

                        this.writer.WriteLine(this.controller.CreateMotorcycle(type, model, horsePower));
                    }
                    else if (command == "AddMotorcycleToRider")
                    {
                        var rider = parts[1];
                        var motorcycle = parts[2];

                        this.writer.WriteLine(this.controller.AddMotorcycleToRider(rider, motorcycle));
                    }
                    else if (command == "AddRiderToRace")
                    {
                        var race = parts[1];
                        var rider = parts[2];

                        this.writer.WriteLine(this.controller.AddRiderToRace(race, rider));
                    }
                    else if (command == "CreateRace")
                    {
                        var race = parts[1];
                        var laps = int.Parse(parts[2]);

                        this.writer.WriteLine(this.controller.CreateRace(race, laps));
                    }
                    else if (command == "StartRace")
                    {
                        var race = parts[1];

                        this.writer.WriteLine(this.controller.StartRace(race));
                    }
                }
                catch (ArgumentException ae)
                {
                    this.writer.WriteLine(ae.Message);
                }
                catch (InvalidOperationException ae)
                {
                    this.writer.WriteLine(ae.Message);
                }
                catch (Exception e)
                {
                    this.writer.WriteLine(e.Message);
                }

                input = this.reader.ReadLine();
            }
        }
    }
}
