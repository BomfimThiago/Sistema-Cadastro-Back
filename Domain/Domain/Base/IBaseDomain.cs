using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Domain.Base
{
   public interface IBaseDomain<T> where T : Entity
      {
            Task<List<T>> GetAllAsync();
            T GetById(Guid id);
            Task AddAsync(T model);
            Task Update(T model);
            Task Delete(Guid id);
        }
    
}
