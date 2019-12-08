namespace MXGP.Repositories
{
    using System.Linq;
    using Models.Motorcycles.Contracts;

    public class MotorcycleRepository : Repository<IMotorcycle>
    {
        public override IMotorcycle GetByName(string name)
        {
            return this.Collection.FirstOrDefault(x => x.Model == name);
        }        
    }
}
