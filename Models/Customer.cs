using System;
using System.ComponentModel.DataAnnotations;

public class Customer
{
    public int CustomerId { get; set; }

    [Required, StringLength(120)]
    public string FullName { get; set; }

    [EmailAddress]
    public string Email { get; set; }

    public string Phone { get; set; }

    public DateTime RegisteredOn { get; set; }
}