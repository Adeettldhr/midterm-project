namespace midterm_project.Exceptions
{
    public class BookNotFoundException : Exception
    {
        public BookNotFoundException(string title)
            : base($"The book '{title}' could not be found in the library database.") { }
    }
}
