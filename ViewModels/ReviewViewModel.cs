using System;
using System.ComponentModel.DataAnnotations;

namespace midterm_project.ViewModels
{
    public class ReviewViewModel
    {
        public int ReviewId { get; set; }

        [Required]
        [Display(Name = "Book")]
        public int BookId { get; set; }

        [Display(Name = "Book Title")]
        public string BookTitle { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Customer")]
        public int CustomerId { get; set; }

        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; } = string.Empty;

        [Required]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
        public int Rating { get; set; }

        [Display(Name = "Comment")]
        [StringLength(1000)]
        public string? Comment { get; set; }

        [Display(Name = "Review Date")]
        [DataType(DataType.Date)]
        public DateTime ReviewDate { get; set; }
    }
}
