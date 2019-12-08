namespace MXGP.Repositories
{
    using System.Linq;
    using MXGP.Models.Riders.Contracts;

    public class RiderRepository : Repository<IRider>
    {
        public override IRider GetByName(string name)
        {
            return this.Collection.FirstOrDefault(x => x.Name == name);
        }
    }
}
