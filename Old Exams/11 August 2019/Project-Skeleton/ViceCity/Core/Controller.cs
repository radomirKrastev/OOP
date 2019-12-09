namespace ViceCity.Core
{
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ViceCity.Models.Guns;
    using ViceCity.Models.Guns.Contracts;
    using ViceCity.Models.Neghbourhoods;
    using ViceCity.Models.Neghbourhoods.Contracts;
    using ViceCity.Models.Players;
    using ViceCity.Models.Players.Contracts;

    public class Controller : IController
    {
        private IPlayer mainPlayer;
        private List<IPlayer> players;
        private Queue<IGun> guns;
        private Neighbourhood neighbourhood;

        public Controller()
        {
            this.players = new List<IPlayer>();
            this.guns = new Queue<IGun>();
            this.mainPlayer = new MainPlayer();
            this.neighbourhood = new GangNeighbourhood();
        }

        public string AddGun(string type, string name)
        {
            switch (type)
            {
                case "Pistol":
                    var pistol = new Pistol(name);
                    this.guns.Enqueue(pistol);
                    return $"Successfully added {name} of type: {type}";
                case "Rifle":
                    var rifle = new Rifle(name);
                    this.guns.Enqueue(rifle);
                    return $"Successfully added {name} of type: {type}";
                default:
                    return "Invalid gun type!";
            }
        }

        public string AddGunToPlayer(string name)
        {
            if (this.guns.Any())
            {
                if (name == this.mainPlayer.Name.Split(" ")[1])
                {
                    this.mainPlayer.GunRepository.Add(this.guns.Dequeue());

                    return $"Successfully added {this.mainPlayer.GunRepository.Models.Last().Name} to the Main Player: Tommy Vercetti";
                }
                else if (!this.players.Any(x => x.Name == name))
                {
                    return "Civil player with that name doesn't exists!";
                }
                else
                {
                    var civilPlayer = this.players.First(x => x.Name == name);
                    civilPlayer.GunRepository.Add(this.guns.Dequeue());

                    return $"Successfully added {civilPlayer.GunRepository.Models.Last().Name} to the Civil Player: {name}";
                }
            }

            return "There are no guns in the queue!";
        }

        public string AddPlayer(string name)
        {
            var player = new CivilPlayer(name);

            this.players.Add(player);

            return $"Successfully added civil player: {name}!";
        }

        public string Fight()
        {
            var actionHappened = false;
            var civils = 0;

            if (this.mainPlayer.GunRepository.Models.Count > 0 && this.players.Any(x => x.IsAlive))
            {
                actionHappened = true;
                civils = this.players.Count();
            }

            this.neighbourhood.Action(this.mainPlayer, this.players);

            if (actionHappened)
            {
                var tommyKills = civils - this.players.Count;

                return $"A fight happened:"
                    + Environment.NewLine
                    + $"Tommy live points: {this.mainPlayer.LifePoints}!"
                    + Environment.NewLine
                    + $"Tommy has killed: {tommyKills} players!"
                    + Environment.NewLine
                    + $"Left Civil Players: {this.players.Count}!";

            }
            else
            {
                return $"Everything is okay!";
            }
        }
    }
}
