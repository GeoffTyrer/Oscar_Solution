using FluentValidation;
using OscarModel_Lib.Models;

namespace OscarModel_Lib.Validators
{
    public class AuthorValidator : AbstractValidator<Author>
    {
        public AuthorValidator()
        {
            RuleFor(x => x.AuthorName).NotEmpty().WithMessage("AuthorName is required");
            RuleFor(x => x.AuthorName).MaximumLength(200).WithMessage("AuthorName must be at most 200 characters");

            RuleFor(x => x.AuthorEmail)
                .EmailAddress().When(x => !string.IsNullOrWhiteSpace(x.AuthorEmail))
                .WithMessage("Invalid email format");

            RuleFor(x => x.AuthorPhone)
                .Length(6, 20).When(x => !string.IsNullOrWhiteSpace(x.AuthorPhone))
                .WithMessage("AuthorPhone must be between 6 and 20 characters");

            RuleFor(x => x.IdAuthor)
                .GreaterThanOrEqualTo(0).WithMessage("IdAuthor must be 0 or greater");
        }
    }
}
