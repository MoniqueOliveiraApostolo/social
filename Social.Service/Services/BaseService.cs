using Social.Domain.Entities;
using Social.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace Social.Service.Services
{
    public class BaseService<T> : IService<T> where T : BaseEntity
    {        
        private IRepository<T> repository;

        public BaseService(IRepository<T> repository)
        {
            this.repository = repository;
        }

        public void Delete(int id)
        {
            if (id == 0)
                throw new ArgumentException("O id não pode ser zero.");

            repository.Remove(id);
        }

        public T Get(int id)
        {
            if (id == 0)
                throw new ArgumentException("O id não pode ser zero.");

            return repository.Select(id);
        }

        public IList<T> Get() => repository.SelectAll();

        public T Post(T obj)
        {
            repository.Insert(obj);
            return obj;
        }

        public T Put(T obj) 
        {
            repository.Update(obj);
            return obj;
        }
    }
}
