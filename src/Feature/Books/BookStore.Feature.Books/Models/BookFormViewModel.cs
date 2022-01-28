using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace BookStore.Feature.Books.Models
{
  public class BookFormViewModel
  {
    [Required(ErrorMessage = "A book must have a unique ISBN")]
    [RegularExpression(@"^[1-9]+[0-9-]{0,20}$", ErrorMessage = "Type in a correct format of ISBN")]
    [Display(Name = "ISBN")]
    public string ISBN { get; set; }

    [Required(ErrorMessage = "The title of the book is required")]
    [Display(Name = "Title of the book")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Number in stock is required")]
    [Display(Name = "Number in stock")]
    [Range(0, 500, ErrorMessage = "The amount of books must be a whole positive number smaller than 500")]
    public short NumberStock { get; set; }

    [Required(ErrorMessage = "Number of pages is required")]
    [Display(Name = "Number of pages")]
    [Range(1, 5000, ErrorMessage = "A book must have a whole number of pages larger, than 0 and smaller than 5000")]
    public short NumberPages { get; set; }

    public IEnumerable<PersonReduced> Authors { get; set; }

    [Required(ErrorMessage = "A book must have at least one author")]
    [Display(Name = "Choose authors from a list || Use Ctrl to select many")]
    public List<Guid> AuthorId { get; set; }

    public PublishingHouseReduced PublishingHouse { get; set; }


    public BookFormViewModel()
    {
      Authors = new List<PersonReduced>();
    }
  }
}
