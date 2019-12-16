namespace AquaShop.Models.Aquariums
{
    public class SaltwaterAquarium : Aquarium
    {
        private const int CapacityConst = 25;

        public SaltwaterAquarium(string name) 
            : base(name, CapacityConst)
        {
        }
    }
}
