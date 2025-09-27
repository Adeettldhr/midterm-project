  namespace LibraryManagement.ViewModels
  {
  	public class BookViewModel
  	{
  		public int BookId { get; set; }
  		public string Title { get; set; }
	public string AuthorName { get; set; }
	public string BranchName { get; set; }
	public string ISBN { get; set; }
public int PublishedYear { get; set; }
public bool IsAvailableForBorrowing { get; set; }


 	}
 }
