namespace midterm_project.Exceptions
{
    public class DatabaseConnectionException : Exception
    {
        public DatabaseConnectionException(string message)
            : base("Unable to connect to the library database.") { }
    }
}
