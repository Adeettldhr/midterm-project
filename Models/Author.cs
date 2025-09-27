using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Author
{
    public int AuthorId { get; set; }

    [Required, StringLength(150)]
    public string Name { get; set; }

    public string Bio { get; set; }

    public ICollection<Book> Books { get; set; }
}