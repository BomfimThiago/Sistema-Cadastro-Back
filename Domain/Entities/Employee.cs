using Domain.Entities.Base;
using Newtonsoft.Json;
using System;


namespace Domain.Entities
{
    public class Employee : Entity
    {
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime? ResignedDate { get; set; }
        public Guid DepartmentId { get; set; }
        
        public Department Department { get; set; }
    }
}
