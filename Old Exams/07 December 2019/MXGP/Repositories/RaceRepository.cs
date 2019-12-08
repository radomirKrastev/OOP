namespace MXGP.Repositories
{
    using System.Linq;
    using Models.Races.Contracts;

    public class RaceRepository : Repository<IRace>
    {
        public override IRace GetByName(string name)
        {
            return this.Collection.FirstOrDefault(x => x.Name == name);
        }
    }
}
