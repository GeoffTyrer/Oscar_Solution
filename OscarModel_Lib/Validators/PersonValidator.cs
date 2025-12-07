using FluentValidation;
using OscarModel_Lib.Models;

namespace OscarModel_Lib.Validators
{
    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("FirstName is required");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("LastName is required");
            RuleFor(x => x.Age).InclusiveBetween(0, 120).WithMessage("Age must be between 0 and 120");
        }
    }
}
