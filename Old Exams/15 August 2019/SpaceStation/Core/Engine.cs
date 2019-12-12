namespace SpaceStation.Core
{
    using System;
    using System.Collections.Generic;
    using SpaceStation.Core.Contracts;
    using SpaceStation.IO;
    using SpaceStation.IO.Contracts;

    public class Engine : IEngine
    {
        private IWriter writer;
        private IReader reader;
        private IController controller;

        public Engine()
        {
            this.writer = new Writer();
            this.reader = new Reader();
            this.controller = new Controller();
        }

        public void Run()
        {
            while (true)
            {
                var input = this.reader.ReadLine().Split();
                if (input[0] == "Exit")
                {
                    Environment.Exit(0);
                }

                try
                {
                    if (input[0] == "AddAstronaut")
                    {
                        var type = input[1];
                        var name = input[2];

                        this.writer.WriteLine(this.controller.AddAstronaut(type, name));
                    }
                    else if (input[0] == "AddPlanet")
                    {
                        var name = input[1];
                        var items = new List<string>();

                        for (int i = 2; i < input.Length; i++)
                        {
                            items.Add(input[i]);
                        }

                        this.writer.WriteLine(this.controller.AddPlanet(name, items.ToArray()));
                    }
                    else if (input[0] == "RetireAstronaut")
                    {
                        var name = input[1];

                        this.writer.WriteLine(this.controller.RetireAstronaut(name));
                    }
                    else if (input[0] == "ExplorePlanet")
                    {
                        var name = input[1];

                        this.writer.WriteLine(this.controller.ExplorePlanet(name));
                    }
                    else if (input[0] == "Report")
                    {
                        this.writer.WriteLine(this.controller.Report());
                    }
                }
                catch (Exception ex)
                {
                    this.writer.WriteLine(ex.Message);
                }
            }
        }
    }
}
