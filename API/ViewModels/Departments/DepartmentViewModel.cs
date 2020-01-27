using System;
using System.Collections.Generic;

namespace API.ViewModels
{
    public class DepartmentViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Imagem { get; set; }
        public List<EmployeeViewModel> Employees { get; set; }
    }
}
