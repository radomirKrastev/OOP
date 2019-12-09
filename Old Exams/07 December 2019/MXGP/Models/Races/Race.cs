namespace MXGP.Models.Races
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using MXGP.Utilities.Messages;
    using Races.Contracts;
    using Riders.Contracts;

    public class Race : IRace
    {
        private string name;
        private int laps;
        private List<IRider> riders;

        public Race(string name, int laps)
        {
            this.Name = name;
            this.Laps = laps;
            this.riders = new List<IRider>();
        }

        public string Name 
        {
            get => this.name;
            
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidModel, value, 5));
                }

                this.name = value;
            }
        }

        public int Laps
        {
            get => this.laps;

            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidNumberOfLaps, 1));
                }

                this.laps = value;
            }
        }

        public IReadOnlyCollection<IRider> Riders => this.riders;

        public void AddRider(IRider rider)
        {
            if (rider == null)
            {
                throw new ArgumentNullException("Rider cannot be null.");
            }
            else if (!rider.CanParticipate)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RiderNotParticipate, rider.Name));
            }
            else if (this.Riders.Any(x => x.Name == rider.Name))
            {
                throw new ArgumentNullException(string.Format(ExceptionMessages.RiderAlreadyAdded, rider.Name, this.Name));
            }

            this.riders.Add(rider);
        }
    }
}
