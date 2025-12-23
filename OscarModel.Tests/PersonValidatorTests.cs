using OscarModel_Lib.Models;
using OscarModel_Lib.Validators;
using Xunit;

namespace OscarModel.Tests
{
    public class PersonValidatorTests
    {
        private readonly PersonValidator _validator = new PersonValidator();

        [Fact]
        public void ValidPerson_PassesValidation()
        {
            var person = new Person { FirstName = "John", LastName = "Doe", Age = 30 };
            var result = _validator.Validate(person);
            Assert.True(result.IsValid);
        }

        [Fact]
        public void MissingNames_FailsValidation()
        {
            var person = new Person { FirstName = "", LastName = "", Age = 30 };
            var result = _validator.Validate(person);
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e => e.PropertyName == "FirstName");
            Assert.Contains(result.Errors, e => e.PropertyName == "LastName");
        }

        [Fact]
        public void AgeOutOfRange_FailsValidation()
        {
            var person = new Person { FirstName = "A", LastName = "B", Age = 200 };
            var result = _validator.Validate(person);
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e => e.PropertyName == "Age");
        }
    }
}
