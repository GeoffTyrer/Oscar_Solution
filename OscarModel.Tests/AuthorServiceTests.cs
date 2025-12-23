using Xunit;
using OscarModel_Lib.Models;
using OscarModel_Lib.Services;

namespace OscarModel.Tests
{
    public class AuthorServiceTests
    {
        [Fact]
        public void CreateAuthor_InvalidModel_ReturnsValidationErrors()
        {
            var service = new AuthorService();

            var author = new Author
            {
                IdAuthor = 1,
                AuthorName = "", // missing required
                AuthorEmail = "not-an-email",
                AuthorPhone = "123"
            };

            var result = service.CreateAuthor(author);

            Assert.False(result.Success);
            Assert.NotNull(result.Errors);
            Assert.Contains(result.Errors, e => e.Path != null && e.Path.Contains("AuthorName"));
            Assert.Contains(result.Errors, e => e.Path != null && e.Path.Contains("AuthorEmail"));
        }
    }
}
