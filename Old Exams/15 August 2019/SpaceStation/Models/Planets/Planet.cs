﻿namespace SpaceStation.Models.Planets
{
    using System;
    using System.Collections.Generic;
    using SpaceStation.Utilities.Messages;

    public class Planet : IPlanet
    {
        private string name;
        private ICollection<string> items;

        public Planet(string name)
        {
            this.items = new List<string>();
            this.Name = name;
        }

        public ICollection<string> Items => this.items;

        public string Name 
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(string.Format(ExceptionMessages.InvalidPlanetName));
                }

                this.name = value;
            }
        }
    }
}
