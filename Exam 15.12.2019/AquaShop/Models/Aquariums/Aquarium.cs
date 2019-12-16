namespace AquaShop.Models.Aquariums
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using AquaShop.Models.Decorations.Contracts;
    using AquaShop.Models.Fish.Contracts;
    using AquaShop.Utilities.Messages;
    using Contracts;

    public abstract class Aquarium : IAquarium
    {
        private string name;
        private int capacity;
        private List<IDecoration> decorations;
        private List<IFish> fish;

        public Aquarium(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.fish = new List<IFish>();
            this.decorations = new List<IDecoration>();
        }

        public string Name
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidAquariumName));
                }

                this.name = value;
            }
        }

        public int Capacity
        {
            get => this.capacity;

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidAquariumCapacity));
                }

                this.capacity = value;
            }
        }

        public int Comfort => this.decorations.Sum(x => x.Comfort);

        public ICollection<IDecoration> Decorations => this.decorations;

        public ICollection<IFish> Fish => this.fish;

        public void AddDecoration(IDecoration decoration)
        {
            this.decorations.Add(decoration);
        }

        public void AddFish(IFish fish)
        {
            if (this.Fish.Count < this.Capacity)
            {
                this.fish.Add(fish);
            }
            else
            {
                throw new InvalidOperationException(string.Format(OutputMessages.NotEnoughCapacity));
            }
        }

        public void Feed()
        {
            this.fish.ForEach(x => x.Eat());
        }

        public string GetInfo()
        {
            var output = new StringBuilder();

            output.AppendLine($"{this.Name} ({this.GetType().Name}):");
            
            if (this.fish.Count > 0)
            {
                output.AppendLine($"Fish: {string.Join(", ", this.fish.Select(x=>x.Name))}");
            }
            else
            {
                output.AppendLine("Fish: none");
            }

            output.AppendLine($"Decorations: {this.decorations.Count}");
            output.AppendLine($"Comfort: {this.Comfort}");

            return output.ToString().TrimEnd();
        }

        public bool RemoveFish(IFish fish)
        {
            if (this.fish.Any(x => x.Name == fish.Name))
            {
                this.fish.Remove(fish);
                return true;
            }

            return false;
        }
    }
}
