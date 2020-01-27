using Domain.Domain.Base;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Domain.Employees
{
    public class EmployeeDomain : BaseDomain<Employee>, IEmployeeDomain
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeDomain(IEmployeeRepository repository) : base(repository)
        {
            _repository = repository;
        }

      
        public Task<List<Employee>> GetEmployeesByDepartmentId(Guid departmentId)
        {
            return _repository.GetEmployeesByDepartmentId(departmentId);
        }

        public  Task<List<Employee>> Search (string q, Guid? departmentId)
        {
            return _repository.Search(q, departmentId);
        }
    }
}
