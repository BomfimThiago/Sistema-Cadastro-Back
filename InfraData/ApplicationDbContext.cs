
using Domain.Entities;
using InfraData.Mapping;
using Microsoft.EntityFrameworkCore;

namespace InfraData
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() { }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration<Employee>(new EmployeeMap());
            modelBuilder.ApplyConfiguration<Department>(new DepartmentMap());
            modelBuilder.ApplyConfiguration<User>(new UserMap());
        }
    }
}
