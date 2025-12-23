using System.Linq;
using FluentValidation;
using Oscar.Shared;
using OscarModel_Lib.Models;
using OscarModel_Lib.Validators;

namespace OscarModel_Lib.Services
{
    public class AuthorService
    {
        private readonly IValidator<Author> _validator;

        public AuthorService(IValidator<Author>? validator = null)
        {
            _validator = validator ?? new AuthorValidator();
        }

        public Result<Author> CreateAuthor(Author author)
        {
            var validationResult = _validator.Validate(author);

            if (!validationResult.IsValid)
            {
                var errors = FluentValidationAdapter.Convert<Author>(validationResult, "author");

                return new Result<Author>
                {
                    Success = false,
                    Data = null,
                    Errors = errors,
                    Message = "Validation failed",
                    StatusCode = 400
                };
            }

            // For this example we simply return the same author as created.
            return new Result<Author>
            {
                Success = true,
                Data = author,
                Errors = System.Array.Empty<ValidationError>(),
                Message = "Created",
                StatusCode = 201
            };
        }
    }
}
