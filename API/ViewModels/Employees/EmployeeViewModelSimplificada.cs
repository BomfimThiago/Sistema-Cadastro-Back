using System;


namespace API.ViewModels.Employees
{
    public class EmployeeViewModelSimplificada
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }

        public Guid DepartmentId { get; set; }
        public DepartmentViewModel Department { get; set; }
    }
}
