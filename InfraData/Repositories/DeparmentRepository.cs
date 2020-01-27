using Domain.Domain.Departments;
using Domain.Entities;

namespace InfraData.Repositories
{
    public class DeparmentRepository : RepositoryBase<Department>, IDepartmentRepository
    {
        public DeparmentRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
