using System;
using System.ComponentModel.DataAnnotations;

namespace midterm_project.ViewModels
{
    public class BorrowRecordViewModel
    {
        public int BorrowRecordId { get; set; }

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
        [DataType(DataType.Date)]
        [Display(Name = "Borrow Date")]
        public DateTime BorrowDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Return Date")]
        public DateTime? ReturnDate { get; set; }

        [Display(Name = "Is Returned")]
        public bool IsReturned { get; set; }
    }
}
