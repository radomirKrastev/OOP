namespace MXGP.Repositories
{
    using System.Collections.Generic;
    using Contracts;

    public abstract class Repository<T> : IRepository<T>
    {
        public Repository()
        {
            this.Collection = new List<T>();
        }

        protected List<T> Collection { get; set; }

        public void Add(T model)
        {
            this.Collection.Add(model);
        }

        public IReadOnlyCollection<T> GetAll() => this.Collection.AsReadOnly();

        public abstract T GetByName(string name);

        public bool Remove(T model)
        {
            if (this.Collection.Contains(model))
            {
                this.Collection.Remove(model);
                return true;
            }

            return false;
        }
    
    }
}
