namespace GreedyTimes.Treasuries
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Bag
    {
        private int goldCount = 0;

        public Bag()
        {
            this.Gold = new Gold();
            this.Gems = new List<Gem>();
            this.Cash = new List<Cash>();
        }

        public long Value { get; private set; }
        public Gold Gold { get; private set; }
        public List<Gem> Gems { get; private set; }
        public List<Cash> Cash { get; private set; }

        public void AddGold(long value)
        {
            if (this.Gold == null)
            {
                this.Gold = new Gold();
            }

            this.Value += value;
            this.Gold.Value += value;
            this.goldCount++;
        }

        public void AddCash(string currency, long additionalValue)
        {
            var currentCashValue = GetCashValue();
            var GemsValue = GetGemValue();

            if (currentCashValue + additionalValue <= GemsValue && this.Gems.Count>0)
            {
                if (!this.Cash.Any(x => x.Name == currency))
                {
                    this.Value += additionalValue;
                    this.Cash.Add(new Cash(currency, additionalValue));
                }
                else
                {
                    this.Value += additionalValue;
                    this.Cash.First(x => x.Name == currency).Value += additionalValue;
                }
            }
        }

        public void AddGem(string type, long additionalValue)
        {
            var GoldValue = GetGoldValue();
            var currentGemsValue = GetGemValue();

            if (currentGemsValue + additionalValue <= GoldValue && this.goldCount>0)
            {
                if (!this.Gems.Any(x => x.Name == type))
                {
                    this.Value += additionalValue;
                    this.Gems.Add(new Gem(type, additionalValue));
                }
                else
                {
                    this.Value += additionalValue;
                    this.Gems.First(x => x.Name == type).Value += additionalValue;
                }
            }
        }

        public override string ToString()
        {
            var output = new StringBuilder();

            if (this.goldCount > 0)
            {
                output.AppendLine($"<Gold> ${this.Gold.Value}");
                output.AppendLine($"##Gold - {this.Gold.Value}");
            }

            if (this.Gems.Count() > 0)
            {
                output.AppendLine($"<Gem> ${this.Gems.Select(x => x.Value).Sum()}");

                foreach (var type in this.Gems.OrderByDescending(x => x.Name).ThenBy(x => x.Value))
                {
                    output.AppendLine($"##{type.Name} - {type.Value}");
                }
            }

            if (this.Cash.Count() > 0)
            {
                output.AppendLine($"<Cash> ${this.Cash.Select(x => x.Value).Sum()}");

                foreach (var type in this.Cash.OrderByDescending(x => x.Name).ThenBy(x => x.Value))
                {
                    output.AppendLine($"##{type.Name} - {type.Value}");
                }
            }

            return output.ToString();
        }

        private long GetCashValue()
        {
            var value = 0L;

            foreach (var currency in this.Cash)
            {
                value += currency.Value;
            }

            return value;
        }

        private long GetGoldValue()
        {
            return this.Gold.Value;
        }

        private long GetGemValue()
        {
            var value = 0L;

            foreach (var type in this.Gems)
            {
                value += type.Value;
            }

            return value;
        }        
    }
}
