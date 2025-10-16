using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace midterm_project.Models
{
    public class Librarian
    {
        [Key]
        public int LibrarianId { get; set; }

        [Required, StringLength(100)]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required, EmailAddress]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required, StringLength(15)]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Hired Date")]
        public DateTime HiredDate { get; set; }

        [Display(Name = "Library Branch")]
        public int LibraryBranchId { get; set; }

        [ForeignKey("LibraryBranchId")]
        public LibraryBranch? LibraryBranch { get; set; }
    }
}
