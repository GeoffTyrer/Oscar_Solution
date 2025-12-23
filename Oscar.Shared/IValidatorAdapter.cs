using System.Collections.Generic;

namespace Oscar.Shared
{
    public interface IValidatorAdapter
    {
        IReadOnlyList<ValidationError> ConvertValidationFailures(object model, object validationResult, string? parameterName = null);
    }
}
