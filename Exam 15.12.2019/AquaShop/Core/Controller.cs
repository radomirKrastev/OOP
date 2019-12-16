namespace AquaShop.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using AquaShop.Models.Aquariums;
    using AquaShop.Models.Aquariums.Contracts;
    using AquaShop.Models.Decorations;
    using AquaShop.Models.Fish;
    using AquaShop.Repositories;
    using AquaShop.Utilities.Messages;
    using Contracts;
   
    public class Controller : IController
    {
        private DecorationRepository decorations;
        private List<IAquarium> aquariums;

        public Controller()
        {
            this.decorations = new DecorationRepository();
            this.aquariums = new List<IAquarium>();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            switch (aquariumType)
            {
                case "FreshwaterAquarium":
                    this.aquariums.Add(new FreshwaterAquarium(aquariumName));
                    return string.Format(OutputMessages.SuccessfullyAdded, aquariumType);
                case "SaltwaterAquarium":
                    this.aquariums.Add(new SaltwaterAquarium(aquariumName));
                    return string.Format(OutputMessages.SuccessfullyAdded, aquariumType);
                default:
                    throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidAquariumType));
            }
        }

        public string AddDecoration(string decorationType)
        {
            switch (decorationType)
            {
                case "Ornament":
                    this.decorations.Add(new Ornament());
                    return string.Format(OutputMessages.SuccessfullyAdded, decorationType);
                case "Plant":
                    this.decorations.Add(new Plant());
                    return string.Format(OutputMessages.SuccessfullyAdded, decorationType);
                default:
                    throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidDecorationType));
            }
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            var aquarium = this.aquariums.First(x => x.Name == aquariumName);

            switch (fishType)
            {
                case "FreshwaterFish":
                    var freshFish = new FreshwaterFish(fishName, fishSpecies, price);

                    if (freshFish.GetType().Name.Split("Fish")[0] != aquarium.GetType().Name.Split("Aquarium")[0])
                    {
                        return string.Format(OutputMessages.UnsuitableWater);
                    }

                    aquarium.AddFish(freshFish);
                    return string.Format(OutputMessages.FishAdded, fishType, aquariumName);
                case "SaltwaterFish":
                    var saltyFish = new SaltwaterFish(fishName, fishSpecies, price);

                    if (saltyFish.GetType().Name.Split("Fish")[0] != aquarium.GetType().Name.Split("Aquarium")[0])
                    {
                        return string.Format(OutputMessages.UnsuitableWater);
                    }

                    aquarium.AddFish(saltyFish);
                    return string.Format(OutputMessages.FishAdded, fishType, aquariumName);
                default:
                    throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidFishType));
            }
        }

        public string CalculateValue(string aquariumName)
        {
            var aquarium = this.aquariums.First(x => x.Name == aquariumName);
            var priceDecoration = aquarium.Decorations.Sum(x => x.Price);
            var priceFish = aquarium.Fish.Sum(x => x.Price);
            var priceTotal = $"{priceDecoration + priceFish:F2}";

            return string.Format(OutputMessages.AquariumValue, aquariumName, priceTotal);
        }

        public string FeedFish(string aquariumName)
        {
            var aquarium = this.aquariums.First(x => x.Name == aquariumName);

            aquarium.Feed();

            return string.Format(OutputMessages.FishFed, aquarium.Fish.Count);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            var aquarium = this.aquariums.First(x => x.Name == aquariumName);
            var decoration = this.decorations.FindByType(decorationType);

            if (decoration == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentDecoration, decorationType));
            }

            aquarium.AddDecoration(decoration);
            this.decorations.Remove(decoration);

            return string.Format(OutputMessages.DecorationAdded, decorationType, aquariumName);
        }

        public string Report()
        {
            var output = new StringBuilder();

            foreach (var aquarium in this.aquariums)
            {
                output.AppendLine($"{aquarium.GetInfo()}");
            }

            return output.ToString().TrimEnd();
        }
    }
}
