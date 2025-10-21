using System.ComponentModel.DataAnnotations;

namespace midterm_project.ViewModels
{
    public class LibrarianViewModel
    {
        public int LibrarianId { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Full Name")]
        public string Name { get; set; } = string.Empty;

        [EmailAddress]
        [Display(Name = "Email Address")]
        public string? Email { get; set; }

        [Phone]
        [Display(Name = "Phone Number")]
        public string? PhoneNumber { get; set; }

        [Display(Name = "Employment Date")]
        [DataType(DataType.Date)]
        public DateTime EmploymentDate { get; set; }

        [Display(Name = "Assigned Branch")]
        public string? BranchName { get; set; }
    }
}
