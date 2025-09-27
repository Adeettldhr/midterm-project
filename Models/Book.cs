using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Book
{
    public int BookId { get; set; }

    [Required, StringLength(250)]
    public string Title { get; set; }

    public int? AuthorId { get; set; }
    public Author Author { get; set; }

    public string ISBN { get; set; }

    public int PublishedYear { get; set; }

    public string Genre { get; set; }

    // You may track availability through BookCopy (see below)
    public ICollection<BookCopy> Copies { get; set; }
}