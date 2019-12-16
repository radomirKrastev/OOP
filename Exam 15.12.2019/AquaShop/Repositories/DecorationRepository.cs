namespace AquaShop.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using AquaShop.Models.Decorations.Contracts;
    using Contracts;

    public class DecorationRepository : IRepository<IDecoration>
    {
        private List<IDecoration> models;

        public DecorationRepository()
        {
            this.models = new List<IDecoration>();
        }

        public IReadOnlyCollection<IDecoration> Models => this.models.AsReadOnly();

        public void Add(IDecoration model)
        {
            this.models.Add(model);
        }

        public IDecoration FindByType(string type)
        {
            return this.Models.FirstOrDefault(x => x.GetType().Name == type);
        }

        public bool Remove(IDecoration model)
        {
            var modelToBeRemoved = this.Models.FirstOrDefault(x => x.Comfort == model.Comfort && x.Price == model.Price);

            if (modelToBeRemoved != null)
            {
                this.models.Remove(modelToBeRemoved);

                return true;
            }

            return false;
        }
    }
}
