namespace ViceCity.Models.Neghbourhoods
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using ViceCity.Models.Players.Contracts;

    public class GangNeighbourhood : INeighbourhood
    {
        public void Action(IPlayer mainPlayer, ICollection<IPlayer> civilPlayers)
        {
            while (civilPlayers.Any(x => x.IsAlive))
            {
                var currentGun = mainPlayer.GunRepository.Models.FirstOrDefault(x => x.CanFire);

                if(currentGun == null)
                {
                    break;
                }

                var civilPlayer = civilPlayers.First(x => x.IsAlive);

                civilPlayer.TakeLifePoints(currentGun.Fire());
            }

            while (civilPlayers.Any(x => x.IsAlive) 
                && civilPlayers.Any(x=>x.GunRepository.Models.Any(y=>y.CanFire)))
            {
                if (!mainPlayer.IsAlive)
                {
                    break;
                }

                var civilPlayer = civilPlayers.First(x => x.IsAlive && x.GunRepository.Models.Any(y => y.CanFire));
                var currentGun = civilPlayer.GunRepository.Models.FirstOrDefault(x => x.CanFire);

                mainPlayer.TakeLifePoints(currentGun.Fire());
            }
        }
    }
}
