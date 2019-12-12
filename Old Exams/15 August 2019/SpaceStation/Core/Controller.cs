namespace SpaceStation.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using Contracts;
    using SpaceStation.Models.Astronauts;
    using SpaceStation.Models.Astronauts.Contracts;
    using SpaceStation.Models.Mission;
    using SpaceStation.Models.Planets;
    using SpaceStation.Repositories;
    using SpaceStation.Repositories.Contracts;
    using Utilities.Messages;

    public class Controller : IController
    {
        private IRepository<IAstronaut> astronauts;
        private IRepository<IPlanet> planets;
        private IMission mission;
        private int exploredPlanets = 0;

        public Controller()
        {
            this.astronauts = new AstronautRepository();
            this.planets = new PlanetRepository();
            this.mission = new Mission();
        }

        public string AddAstronaut(string type, string astronautName)
        {
            var astronautType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(x => x.Name == type);

            if (astronautType == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidAstronautType));
            }

            var astronautModel = (IAstronaut)Activator.CreateInstance(astronautType, astronautName);
            this.astronauts.Add(astronautModel);
            return string.Format(OutputMessages.AstronautAdded, type, astronautName);

            ////switch (type)
            ////{
            ////    case "Biologist":
            ////        var bio = new Biologist(astronautName);
            ////        this.astronauts.Add(bio);
            ////        return string.Format(OutputMessages.AstronautAdded, type, astronautName);
            ////    case "Geodesist":
            ////        var geo = new Geodesist(astronautName);
            ////        this.astronauts.Add(geo);
            ////        return string.Format(OutputMessages.AstronautAdded, type, astronautName);
            ////    case "Meteorologist":
            ////        var astronautModel = new Meteorologist(astronautName);
            ////        this.astronauts.Add(astronautModel);
            ////        return string.Format(OutputMessages.AstronautAdded, type, astronautName);
            ////    default:
            ////        throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidAstronautType));
            ////}
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            var newPlanet = new Planet(planetName);

            if (items.Any())
            {
                foreach (var item in items)
                {
                    newPlanet.Items.Add(item);
                }
            }

            this.planets.Add(newPlanet);

            return string.Format(OutputMessages.PlanetAdded, planetName);
        }

        public string ExplorePlanet(string planetName)
        {
            var astronautsDeployed = new List<IAstronaut>();

            foreach (var astronaut in this.astronauts.Models.Where(x => x.Oxygen > 60))
            {
                astronautsDeployed.Add(astronaut);
            }

            if (astronautsDeployed.Count == 0)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidAstronautCount));
            }

            var planet = this.planets.FindByName(planetName);
            this.mission.Explore(planet, astronautsDeployed);
            var dead = astronautsDeployed.Where(x => x.CanBreath == false).Count();
            this.exploredPlanets++;

            return string.Format(OutputMessages.PlanetExplored, planetName, dead);
        }

        public string Report()
        {
            var output = new StringBuilder();

            output.AppendLine($"{this.exploredPlanets} planets were explored!");
            output.AppendLine($"Astronauts info:");

            foreach (var astronaut in this.astronauts.Models)
            {
                output.AppendLine($"Name: {astronaut.Name}");
                output.AppendLine($"Oxygen: {astronaut.Oxygen}");

                if (astronaut.Bag.Items.Any())
                {
                    output.AppendLine($"Bag items: {string.Join(", ", astronaut.Bag.Items)}");                    
                }
                else
                {
                    output.AppendLine("Bag items: none");
                }
            }

            return output.ToString().TrimEnd();
        }

        public string RetireAstronaut(string astronautName)
        {
            var retiredAstronaut = this.astronauts.FindByName(astronautName);

            if (retiredAstronaut == null || !retiredAstronaut.CanBreath)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRetiredAstronaut, astronautName));
            }

            this.astronauts.Remove(retiredAstronaut);

            return string.Format(string.Format(OutputMessages.AstronautRetired, astronautName));
        }
    }
}
