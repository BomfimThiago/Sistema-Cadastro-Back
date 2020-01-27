using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Domain.Base
{
    public abstract class BaseDomain<T> : IBaseDomain<T> where T : Entity
    {
        private readonly IRepositoryBase<T> _repository;

        public BaseDomain(IRepositoryBase<T> repository)
        {
            _repository = repository;
        }

        public virtual Task AddAsync(T model)
        {
            return _repository.AddAsync(model);
        }

        public virtual Task Delete(Guid id)
        {
            return _repository.Delete(id);
        }

        public virtual Task<List<T>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public virtual T GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        public virtual Task Update(T model)
        {
            return _repository.Update(model);
        }
    }
}
