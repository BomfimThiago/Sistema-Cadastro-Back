using API.ViewModels;
using API.ViewModels.Employees;
using AutoMapper;
using Domain.Entities;

namespace API.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Department, DepartmentViewModel>();
            CreateMap<Employee, EmployeeViewModel>();
            CreateMap<Employee, EmployeeViewModelSimplificada>();

            CreateMap<DepartmentViewModel, Department>();
            CreateMap<EmployeeViewModel, Employee>();
            CreateMap<EmployeeViewModelSimplificada, Employee>();
        }
    }
}
