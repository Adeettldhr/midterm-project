using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace midterm_project.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }

        [Required]
        [Display(Name = "Book")]
        public int BookId { get; set; }

        [ForeignKey("BookId")]
        public Book? Book { get; set; }

        [Required]
        [Display(Name = "Customer")]
        public int CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public Customer? Customer { get; set; }

        [Required]
        [StringLength(500)]
        [Display(Name = "Review Text")]
        public string Comment { get; set; }

        [Range(1, 5)]
        [Display(Name = "Rating (1–5)")]
        public int Rating { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Review Date")]
        public DateTime ReviewDate { get; set; } = DateTime.Now;
    }
}
