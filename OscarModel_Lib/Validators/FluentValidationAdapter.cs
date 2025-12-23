using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;
using Oscar.Shared;

namespace OscarModel_Lib.Validators
{
    public static class FluentValidationAdapter
    {
        public static IReadOnlyList<ValidationError> Convert<T>(ValidationResult validationResult, string? parameterName = null)
        {
            var list = new List<ValidationError>();

            foreach (var failure in validationResult.Errors ?? Enumerable.Empty<ValidationFailure>())
            {
                var prop = failure.PropertyName ?? string.Empty;
                var path = string.IsNullOrEmpty(parameterName) ? prop : $"/{parameterName}/{prop}";

                list.Add(new ValidationError
                {
                    Parameter = string.IsNullOrEmpty(parameterName) ? prop.Split('.').FirstOrDefault() ?? string.Empty : parameterName,
                    Path = path,
                    Message = failure.ErrorMessage,
                    Code = string.IsNullOrEmpty(failure.ErrorCode) ? null : failure.ErrorCode,
                    AttemptedValue = failure.AttemptedValue
                });
            }

            return list;
        }
    }
}
