using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Feature.Authors.Models
{
  public class DetailsViewModel
  {
    public string Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string FullName
    {
      get { return LastName + " " + FirstName; }
    }

    public byte? Rating { get; set; }

    public ICollection<BookReduced> Books { get; set; }

    public DetailsViewModel()
    {
      Books = new List<BookReduced>();
    }
  }

  public class BookReduced
  {
    public string ISBN { get; set; }

    public string Name { get; set; }
  }
}
