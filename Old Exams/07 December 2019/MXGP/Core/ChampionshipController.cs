namespace MXGP.Core
{
    using System;
    using System.Linq;
    using System.Text;
    using Contracts;
    using MXGP.Models.Motorcycles;
    using MXGP.Models.Motorcycles.Contracts;    
    using MXGP.Models.Races;
    using MXGP.Models.Races.Contracts;
    using MXGP.Models.Riders;
    using MXGP.Models.Riders.Contracts;
    using MXGP.Repositories;
    using MXGP.Repositories.Contracts;
    using MXGP.Utilities.Messages;

    public class ChampionshipController : IChampionshipController
    {
        private IRepository<IMotorcycle> motorcycles;
        private IRepository<IRace> races;
        private IRepository<IRider> riders;
        
        public ChampionshipController()
        {
            this.motorcycles = new MotorcycleRepository();
            this.races = new RaceRepository();
            this.riders = new RiderRepository();
        }

        public string AddMotorcycleToRider(string riderName, string motorcycleModel)
        {
            var rider = this.riders.GetByName(riderName);

            if (rider == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RiderNotFound, riderName));
            }

            var motorcycle = this.motorcycles.GetByName(motorcycleModel);

            if (motorcycle == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.MotorcycleNotFound, motorcycleModel));
            }

            rider.AddMotorcycle(motorcycle);

            return string.Format(OutputMessages.MotorcycleAdded, riderName, motorcycleModel);
        }

        public string AddRiderToRace(string raceName, string riderName)
        {
            var race = this.races.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            var rider = this.riders.GetByName(riderName);

            if (rider == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RiderNotFound, riderName));
            }

            race.AddRider(rider);

            return string.Format(OutputMessages.RiderAdded, riderName, raceName);
        }

        public string CreateMotorcycle(string type, string model, int horsePower)
        {
            var motorcycle = this.motorcycles.GetByName(model);

            if (motorcycle != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.MotorcycleExists, model));
            }
                        
            switch (type.ToLower())
            {
                case "power":
                    var power = new PowerMotorcycle(model, horsePower);
                    this.motorcycles.Add(power);
                    break;
                case "speed":
                    var speed = new SpeedMotorcycle(model, horsePower);
                    this.motorcycles.Add(speed);
                    break;
            }

            return string.Format(OutputMessages.MotorcycleCreated, type + "Motorcycle", model);
        }

        public string CreateRace(string name, int laps)
        {
            var race = this.races.GetByName(name);

            if (race != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, name));
            }

            var newRace = new Race(name, laps);
            this.races.Add(newRace);

            return string.Format(OutputMessages.RaceCreated, name);
        }

        public string CreateRider(string riderName)
        {
            var rider = this.riders.GetByName(riderName);

            if (rider != null)
            {
                throw new ArgumentException(ExceptionMessages.RiderExists, riderName);
            }

            var newRider = new Rider(riderName);
            this.riders.Add(newRider);

            return string.Format(OutputMessages.RiderCreated, riderName);
        }

        public string StartRace(string raceName)
        {
            var output = new StringBuilder();

            var race = this.races.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            if (race.Riders.Count < 3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, raceName, 3));
            }

            var topRacers = race.Riders.OrderByDescending(x => x.Motorcycle.CalculateRacePoints(race.Laps)).ToArray();

            var first = topRacers[0];
            var second = topRacers[1];
            var third = topRacers[2];

            output.AppendLine(string.Format(OutputMessages.RiderFirstPosition, first.Name, raceName));
            output.AppendLine(string.Format(OutputMessages.RiderSecondPosition, second.Name, raceName));
            output.AppendLine(string.Format(OutputMessages.RiderThirdPosition, third.Name, raceName));

            this.races.Remove(race);

            return output.ToString().TrimEnd();
        }
    }
}
