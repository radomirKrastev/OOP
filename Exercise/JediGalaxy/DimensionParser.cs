namespace JediGalaxy
{
    using System;
    using System.Linq;

    public class DimensionParser
    {
        public int [] Parse (string dimension)
        {
            return dimension
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
