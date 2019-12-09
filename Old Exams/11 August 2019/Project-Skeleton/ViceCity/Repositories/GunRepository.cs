namespace ViceCity.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using ViceCity.Models.Guns.Contracts;

    public class GunRepository : IRepository<IGun>
    {
        private List<IGun> models;

        public GunRepository()
        {
            this.models = new List<IGun>();
        }

        public IReadOnlyCollection<IGun> Models => this.models;

        public void Add(IGun model)
        {
            if(this.Models.Any(x=>x.Name == model.Name))
            {
                return;
            }

            this.models.Add(model);
        }

        public IGun Find(string name)
        {
            return this.Models.First(x => x.Name == name);
        }

        public bool Remove(IGun model)
        {
            if (this.Models.Contains(model))
            {
                this.models.Remove(model);

                return true;
            }

            return false;
        }
    }
}
