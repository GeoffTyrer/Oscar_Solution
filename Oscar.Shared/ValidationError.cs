using System.Collections.Generic;

namespace Oscar.Shared
{
    public class ValidationError
    {
        public string Parameter { get; set; } = string.Empty;
        public string? Path { get; set; }
        public string Message { get; set; } = string.Empty;
        public string? Code { get; set; }
        public object? AttemptedValue { get; set; }
        public IDictionary<string, object>? Metadata { get; set; }
    }
}
