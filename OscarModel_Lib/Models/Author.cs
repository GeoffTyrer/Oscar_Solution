using System;
using System.ComponentModel.DataAnnotations;

namespace OscarModel_Lib.Models
{
    /// <summary>
    /// An Author is someone who creates Reminiscences
    /// </summary>
    public class Author
    {
        /// <summary>
        /// The unique identifier of an Author
        /// </summary>
        [Key]
        [Required]
        [Range(0, int.MaxValue)]
        public int IdAuthor { get; set; }

        /// <summary>
        /// The name of the Author
        /// </summary>
        [Required]
        public string AuthorName { get; set; } = string.Empty;

        /// <summary>
        /// The email address of an Author
        /// </summary>
        [EmailAddress]
        [StringLength(320)]
        public string? AuthorEmail { get; set; }

        /// <summary>
        /// The phone number of an Author
        /// </summary>
        [StringLength(20, MinimumLength = 6)]
        public string? AuthorPhone { get; set; }
    }
}
