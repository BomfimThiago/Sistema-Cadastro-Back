using Domain.Domain.Base;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Domain.Employees
{
    public interface IEmployeeRepository : IRepositoryBase<Employee>
    {
       
        Task<List<Employee>> Search(string q, Guid? departmentId);
        Task<List<Employee>> GetEmployeesByDepartmentId(Guid departmentId);
    }
}
