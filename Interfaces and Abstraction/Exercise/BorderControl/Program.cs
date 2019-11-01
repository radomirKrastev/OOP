namespace BorderControl
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var borderPassers = new List<Passer>();

            var inputLine = Console.ReadLine();

            while (inputLine != "End")
            {
                var dataParts = inputLine.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                if (dataParts.Length == 2)
                {
                    var model = dataParts[0];
                    var id = dataParts[1];

                    borderPassers.Add(new Robot(model, id));
                }
                else
                {
                    var name = dataParts[0];
                    var age = int.Parse(dataParts[1]);
                    var id = dataParts[2];

                    borderPassers.Add(new Citizen(name, age, id));
                }

                inputLine = Console.ReadLine();
            }

            var falseIds = long.Parse(Console.ReadLine());

            borderPassers
                .Where(x => x.CheckIdValidity(falseIds) == false)
                .Select(x => x.Id)
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}
