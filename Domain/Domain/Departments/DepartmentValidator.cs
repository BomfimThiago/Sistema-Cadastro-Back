using Domain.Entities;
using FluentValidation;

namespace Domain.Domain.Departments
{
    public class DepartmentValidator: AbstractValidator<Department>
    {
        public DepartmentValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .MinimumLength(3).WithMessage("Please specify a name with minimum of 3 letters");

            RuleFor(x => x.Description).NotNull().NotEmpty().MaximumLength(20);
            
            RuleFor(x => x.Image).NotNull().NotEmpty();
        }
    }
}
