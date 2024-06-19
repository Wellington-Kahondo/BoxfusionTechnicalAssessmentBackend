using Abp.Dependency;
using Abp.Domain.Repositories;
using FluentValidation;
using System.Linq;
using System.Text.RegularExpressions;

namespace Boxfusion.TechnicalAssessment.Domain.Employees
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is required");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is required");
            RuleFor(x => x).Custom((entity, context) => {

                if(ValidateEmail(entity.EmailAddress))
                {
                    context.AddFailure("Email address is not valid");
                }

                var repo = IocManager.Instance.Resolve<IRepository<Employee, string>>();
                var exist = repo.GetAllList().Any(x => x.EmailAddress == entity.EmailAddress);

                if (!exist)
                {
                    context.AddFailure("Email address already exists");
                }

            });
        }

        // Custom validation method for emails
        private bool ValidateEmail(string email)
        {
            Regex regex = new Regex("^[a-zA-Z0-9.!#$%&'*+\\/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$");
            Match match = regex.Match(email);
            return match.Success;
        }
    }
}
