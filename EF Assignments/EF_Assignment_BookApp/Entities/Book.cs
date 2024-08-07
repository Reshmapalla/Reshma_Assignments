using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EF_Assignment_BookApp.Entities;

public partial class Book
{
    [Required(ErrorMessage ="please enter Id")]
    public int BookId { get; set; }
    [Required(ErrorMessage = "please enter name")]
    public string? BookName { get; set; }
    [Required(ErrorMessage = "please enter price")]

    public int? Price { get; set; }
    [Required(ErrorMessage = "please enter Author")]

    public string? Author { get; set; }
    [Required(ErrorMessage = "please enter language")]

    public string? Language { get; set; }
    [Required(ErrorMessage = "please enter Date")]

    public DateOnly? Releasedate { get; set; }
}
