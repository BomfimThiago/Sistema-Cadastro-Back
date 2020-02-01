using Domain.Entities.Base;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Department : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
