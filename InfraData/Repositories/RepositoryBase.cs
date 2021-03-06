﻿using Domain.Domain.Base;
using Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InfraData.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : Entity
    {
        private readonly ApplicationDbContext _context;

        public RepositoryBase(ApplicationDbContext context)
        {
            _context = context;
        }

        public virtual async Task AddAsync(T model)
        {
            await _context.Set<T>().AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public Task Delete(Guid id)
        {
            _context.Set<T>().Remove(GetById(id));
            _context.SaveChanges();

            return Task.CompletedTask;
        }

        public virtual Task<List<T>> GetAllAsync()
        {
            return _context.Set<T>().ToListAsync();
        }

        public virtual T GetById(Guid id)
        {
            return  _context.Set<T>().Find(id);
        }

        public virtual Task Update(T model)
        {
            _context.Set<T>().Update(model);
            _context.SaveChanges();

            return Task.CompletedTask;
        }
    }
}
