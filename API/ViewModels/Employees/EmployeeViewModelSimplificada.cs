using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.ViewModels.Employees
{
    public class EmployeeViewModelSimplificada
    {
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }

        public Guid DepartmentId { get; set; }
        public DepartmentViewModel Department { get; set; }
    }
}
