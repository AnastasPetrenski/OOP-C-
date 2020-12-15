using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace EasterRaces.Repositories.Entities
{
    public abstract class Repository<T> : IRepository<T>
    {
        private ICollection<T> models;

        public Repository()
        {
            this.models = new List<T>();
        }

        public ICollection<T> Models => models;

        public void Add(T model)
            => this.models.Add(model);
        
        public IReadOnlyCollection<T> GetAll()
            => this.models.ToList().AsReadOnly();

        public abstract T GetByName(string name);

        public bool Remove(T model)
            => this.models.Remove(model);
    }
}
