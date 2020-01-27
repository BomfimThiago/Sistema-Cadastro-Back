
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InfraData
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration<Employee>(new EmployeeMap());
            modelBuilder.ApplyConfiguration<Department>(new DepartmentMap());
        }
    }
}
