namespace GreedyTimes
{
    using System;
    using Treasuries;

    public class Program
    {
        static void Main()
        {
            var bagLimit = long.Parse(Console.ReadLine());
            var vault = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var newBag = new Bag();

            for (int i = 0; i < vault.Length; i += 2)
            {
                var treasureName = vault[i];
                var category = GetTreasureCategory(treasureName);

                var treasuryValue = long.Parse(vault[i + 1]);
                var bagIsFull = ValidateValue(treasuryValue, bagLimit, newBag);

                if (bagIsFull)
                {
                    continue;
                }

                switch (category)
                {
                    case "Gem":
                        newBag.AddGem(treasureName, treasuryValue);
                        break;
                    case "Cash":
                        newBag.AddCash(treasureName, treasuryValue);
                        break;
                    case "Gold":
                        newBag.AddGold(treasuryValue);
                        break;
                }
            }

            Console.Write(newBag.ToString());
        }

        private static bool ValidateValue(long value, long limit, Bag bag)
        {
            if (limit < bag.Value + value)
            {
                return true;
            }

            return false;
        }

        private static string GetTreasureCategory(string type)
        {
            var category = string.Empty;

            if (type.Length == 3)
            {
                category = "Cash";
            }
            else if (type.ToLower().EndsWith("gem"))
            {
                category = "Gem";
            }
            else if (type.ToLower() == "gold")
            {
                category = "Gold";
            }

            return category;
        }
    }
}