using System.Collections.Generic;

namespace API.ViewModels
{
    public class DepartmentViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public List<EmployeeViewModel> Employees { get; set; }
    }
}
