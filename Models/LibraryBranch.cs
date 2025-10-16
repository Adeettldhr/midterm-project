using System;
using System.ComponentModel.DataAnnotations;

namespace midterm_project.Models
{
    public class LibraryBranch
    {
        public int LibraryBranchId { get; set; }

        [Required(ErrorMessage = "Branch name is required")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; } = string.Empty;

        [Phone(ErrorMessage = "Invalid phone number")]
        public string? Phone { get; set; }

        [DataType(DataType.Date)]
        public DateTime OpenDate { get; set; } = DateTime.Now;
    }
}
