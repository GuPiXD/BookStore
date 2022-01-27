using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Feature.CheckoutHistorys.Models
{
  public class IndexViewModel
  {
    public string Id { get; set; }

    public ClientReduced Client { get; set; }

    public BookReduced Book { get; set; }

    public DateTime CheckoutDate { get; set; }

    public DateTime? ReturnDate { get; set; }
  }

  public class ClientReduced
  {
    public string Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string FullName
    {
      get { return LastName + " " + FirstName; }
    }
  }

  public class BookReduced
  {
    public string ISBN { get; set; }

    public string Name { get; set; }
  }
}
