using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Feature.Books.Models
{
  public class CheckoutFormViewModel
  {
    [Required(ErrorMessage = "A book must be selected for it to be checked out")]
    public string ISBN { get; set; }

    [Required(ErrorMessage = "Must select a client to check out a book")]
    [Display(Name = "Choose, which client will be checking out the book")]
    public string ClientId { get; set; }

    public string Name { get; set; }


    public IEnumerable<PersonReduced> Authors { get; set; }

    public IEnumerable<PersonReduced> Clients { get; set; }



    public DateTime CheckoutDate { get; set; }

    public DateTime? ReturnDate { get; set; }

    public CheckoutFormViewModel()
    {
      Clients = new List<PersonReduced>();

      Authors = new List<PersonReduced>();
    }
  }
}
