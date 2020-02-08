using System;

namespace API.ViewModels.Employees
{
    public class EmployeeViewModelCadastro 
    {
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime? ResignedDate { get; set; }
        public Guid DepartmentId { get; set; }

    }
}
