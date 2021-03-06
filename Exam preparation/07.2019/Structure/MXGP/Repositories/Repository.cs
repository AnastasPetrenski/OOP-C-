﻿using MXGP.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MXGP.Repositories
{
    public abstract class Repository<T> : IRepository<T>
    {
        private ICollection<T> models;

        public Repository()
        {
            this.models = new List<T>();
        }

        public void Add(T model)
        {
            this.models.Add(model);
        }

        public IReadOnlyCollection<T> GetAll()
            => this.models.ToList().AsReadOnly();

        public T GetByName(string name)
        {
            return this.models.FirstOrDefault(GetModelByName(name));
        }

        protected abstract Func<T, bool> GetModelByName(string name);
        
        public bool Remove(T model)
        {
            return this.models.Remove(model);
        }
    }
}
