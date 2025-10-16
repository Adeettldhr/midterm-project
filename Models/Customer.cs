using System.ComponentModel.DataAnnotations;

namespace midterm_project.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Full name is required")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; } = string.Empty;

        [Phone(ErrorMessage = "Invalid phone number")]
        public string? Phone { get; set; }  // renamed to Phone

        public string? Address { get; set; }

        [DataType(DataType.Date)]
        public DateTime RegisteredOn { get; set; } = DateTime.Now;
    }
}
