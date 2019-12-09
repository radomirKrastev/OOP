namespace ViceCity.Core
{
    using System;
    using ViceCity.Core.Contracts;
    using ViceCity.IO;
    using ViceCity.IO.Contracts;    

    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private IController controller;

        public Engine()
        {
            this.reader = new Reader();
            this.writer = new Writer();
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
                    if (input[0] == "AddPlayer")
                    {
                        var name = input[1];

                        this.writer.WriteLine(this.controller.AddPlayer(name));
                    }
                    else if (input[0] == "AddGun")
                    {
                        var type = input[1];
                        var name = input[2];

                        this.writer.WriteLine(this.controller.AddGun(type, name));
                    }
                    else if (input[0] == "AddGunToPlayer")
                    {
                        var name = input[1];

                        this.writer.WriteLine(this.controller.AddGunToPlayer(name));
                    }
                    else if (input[0] == "Fight")
                    {
                        this.writer.WriteLine(this.controller.Fight());
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
