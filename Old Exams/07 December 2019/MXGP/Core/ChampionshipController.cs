namespace MXGP.Core
{
    using Contracts;
    using MXGP.Models.Motorcycles.Contracts;
    using MXGP.Models.Races.Contracts;
    using MXGP.Models.Riders;
    using MXGP.Models.Riders.Contracts;
    using MXGP.Repositories.Contracts;
    using MXGP.Utilities.Messages;
    using System;
    using System.Collections.Generic;

    public class ChampionshipController : IChampionshipController
    {
        private IRepository<IMotorcycle> motorcycles;
        private IRepository<IRace> races;
        private IRepository<IRider> riders;
        
        public string AddMotorcycleToRider(string riderName, string motorcycleModel)
        {
            throw new System.NotImplementedException();
        }

        public string AddRiderToRace(string raceName, string riderName)
        {
            throw new System.NotImplementedException();
        }

        public string CreateMotorcycle(string type, string model, int horsePower)
        {
            throw new System.NotImplementedException();
        }

        public string CreateRace(string name, int laps)
        {
            throw new System.NotImplementedException();
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
            throw new System.NotImplementedException();
        }
    }
}
