﻿namespace SpaceStation.Models.Mission
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SpaceStation.Models.Astronauts.Contracts;
    using SpaceStation.Models.Planets;

    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            foreach (var astronaut in astronauts)
            {
                while (astronaut.CanBreath && planet.Items.Count > 0)
                {
                    var planetMaterial = planet.Items.First();
                    astronaut.Bag.Items.Add(planetMaterial);
                    planet.Items.Remove(planetMaterial);
                    astronaut.Breath();
                }                
            }
        }
    }
}
