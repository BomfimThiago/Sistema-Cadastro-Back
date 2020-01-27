using Domain.Entities;
using FluentValidation;

namespace Domain.Domain.Employees
{
    public class EmployeeValidator: AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().MinimumLength(3)
              .WithMessage("Please specify a name with minimum of 3 letters");

            RuleFor(x => x.Contact).NotNull().NotEmpty();

            RuleFor(x => x.Cpf).NotNull().Length(11);

            RuleFor(x => x.Email).NotNull().NotEmpty().EmailAddress();

            RuleFor(x => x.Age).NotNull().Must(AgeValidation)
              .WithMessage("Age must be equal or greater than 18");

            RuleFor(x => x.JoinDate).NotNull().NotEmpty();

            RuleFor(x => x.DepartmentId).NotNull();
        }

        private bool AgeValidation(int age)
        {
            return age >= 18;
        }

    }
}
