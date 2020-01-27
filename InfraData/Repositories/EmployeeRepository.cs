using Domain.Domain.Employees;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfraData.Repositories
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context) : base(context)
        {
           _context = context;
        }

        public Task<List<Employee>> GetEmployeesByDepartmentId(Guid departmentId)
        {
            return _context.Employees
                .Where(x => x.DepartmentId == departmentId).ToListAsync();
        }

        public Task<List<Employee>> Search(string q, Guid? departmentId)
        {
            var employees = _context.Employees 
                .Where(x => string.IsNullOrEmpty(q) || EF.Functions.Like(x.Name, $"%{q}%") 
                || !departmentId.HasValue || x.DepartmentId == departmentId);

            return employees.ToListAsync();
        }
    }
}
