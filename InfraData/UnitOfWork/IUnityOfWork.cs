using Domain.Domain.Base;
using Domain.Entities;

namespace InfraData.UnitOfWork
{
    public interface IUnityOfWork
    { 
        IRepositoryBase<Department> DepartmentRepository { get; }
        IRepositoryBase<Employee> EmployeeRepository { get; }

        void Commit();
    }
}
