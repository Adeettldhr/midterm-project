using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace midterm_project.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        // Optional: Relationship — One Category can have many Books
        public List<Book>? Books { get; set; }
    }
}
