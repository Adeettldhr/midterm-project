namespace midterm_project.ViewModels
{
public class CustomerViewModel
{
public int CustomerId { get; set; }
public required string Name { get; set; }
public required string Email { get; set; }
public string? Phone { get; set; }
public required string MembershipDateFormatted { get; set; }
}
}