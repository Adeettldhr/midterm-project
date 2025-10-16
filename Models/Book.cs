using System.ComponentModel.DataAnnotations;
namespace midterm_project.Models
{

public class Book
{
    public int BookId { get; set; }

           [Required(ErrorMessage = "Title is required")]

    public string Title { get; set; } = string.Empty;

        public int? AuthorId { get; set; }

        // Navigation property
        public Author? Author { get; set; }

    public string ISBN { get; set; }

    public int PublishedYear { get; set; }

    public string Genre { get; set; }

    // You may track availability through BookCopy (see below)

}
}