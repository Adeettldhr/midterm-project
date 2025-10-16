using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace midterm_project.Models
{
    public class Author
    {
        public int AuthorId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }

        public string? Bio { get; set; }

        public ICollection<Book>? Books { get; set; }
    }
}
