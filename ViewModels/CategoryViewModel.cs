using System.ComponentModel.DataAnnotations;

namespace midterm_project.ViewModels
{
    public class CategoryViewModel
    {
        public int CategoryId { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Category Name")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Description")]
        public string? Description { get; set; }

        // Optional: Number of books in this category
        [Display(Name = "Number of Books")]
        public int BookCount { get; set; }
    }
}
