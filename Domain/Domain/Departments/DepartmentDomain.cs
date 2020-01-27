using Domain.Domain.Base;
using Domain.Entities;

namespace Domain.Domain.Departments
{
    public class DepartmentDomain : BaseDomain<Department>, IDepartmentDomain
    {
        private readonly IDepartmentRepository _repository;

        public DepartmentDomain(IDepartmentRepository repository): base(repository)
        {
            _repository = repository;
        }
    }
}
