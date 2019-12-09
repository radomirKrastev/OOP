using ViceCity.Models.Guns.Contracts;
using System.Collections.Generic;

namespace ViceCity.Repositories.Contracts
{
    public interface IRepository<T>
    {
        IReadOnlyCollection<T> Models { get; }

        void Add(IGun model);

        bool Remove(IGun model);

        IGun Find(string name);
    }
}
