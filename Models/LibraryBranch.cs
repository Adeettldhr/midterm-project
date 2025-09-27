using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class LibraryBranch
{
    public int LibraryBranchId { get; set; }

    [Required, StringLength(200)]
    public string Name { get; set; }

    public string Address { get; set; }


}