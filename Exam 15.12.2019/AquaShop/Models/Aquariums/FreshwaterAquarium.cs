namespace AquaShop.Models.Aquariums
{
    public class FreshwaterAquarium : Aquarium
    {
        private const int CapacityConst = 50;

        public FreshwaterAquarium(string name) 
            : base(name, CapacityConst)
        {
        }
    }
}
