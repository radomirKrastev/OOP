namespace BorderControl
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var bornCreatures = new List<IBirthable>();

            var inputLine = Console.ReadLine();

            while (inputLine != "End")
            {
                var dataParts = inputLine.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                if (dataParts[0] == "Citizen")
                {
                    var name = dataParts[1];
                    var age = int.Parse(dataParts[2]);
                    var id = dataParts[3];

                    var birthdate = DateTime
                        .ParseExact(dataParts[4], "dd'/'MM'/'yyyy", CultureInfo.InvariantCulture);
                    
                    bornCreatures.Add(new Citizen(name, age, id, birthdate));
                }
                else if (dataParts[0] == "Pet")
                {
                    var name = dataParts[1];

                    var birthdate = DateTime
                        .ParseExact(dataParts[2], "dd'/'MM'/'yyyy", CultureInfo.InvariantCulture);

                    bornCreatures.Add(new Pet(name, birthdate));
                }

                inputLine = Console.ReadLine();
            }

            var birthYear = int.Parse(Console.ReadLine());

            bornCreatures
                .Where(x => x.BirthDate.Year == birthYear)
                .Select(x => x.BirthDate)
                .ToList()
                .ForEach(x => Console.WriteLine($"{x.ToString("dd'/'MM'/'yyyy")}"));
        }
    }
}
