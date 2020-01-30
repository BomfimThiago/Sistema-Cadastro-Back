using Domain.Domain.Base;
using Domain.Entities;
using InfraData.Repositories;
using System;

namespace InfraData.UnitOfWork
{
    public class UnitOfWork : IUnityOfWork, IDisposable
    {
        private ApplicationDbContext _context = null;
        private RepositoryBase<Department> departmentRepository = null;
        private RepositoryBase<Employee> employeeRepository = null;

        public UnitOfWork()
        {
            _context = new ApplicationDbContext();
        }
        public void Commit()
        {
            _context.SaveChanges();
        }
        public IRepositoryBase<Department> DepartmentRepository
        {
            get
            {
                if(departmentRepository == null)
                {
                    departmentRepository = new RepositoryBase<Department>(_context);
                }
                return departmentRepository;
            }
        }
        public IRepositoryBase<Employee> EmployeeRepository
        {
            get
            {
                if (employeeRepository == null)
                {
                    employeeRepository = new RepositoryBase<Employee>(_context);
                }
                return employeeRepository;
            }
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if(!this.disposed)
            {
                if(disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
