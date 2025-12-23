using System;
using System.Collections.Generic;

namespace Oscar.Shared
{
    public class Result<T>
    {
        public bool Success { get; set; }
        public T? Data { get; set; }
        public IReadOnlyList<ValidationError> Errors { get; set; } = Array.Empty<ValidationError>();
        public string? Message { get; set; }
        public int? StatusCode { get; set; }
    }
}
